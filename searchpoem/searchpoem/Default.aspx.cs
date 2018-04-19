using Nest;
using searchpoem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace searchpoem
{
    public partial class Default : System.Web.UI.Page
    {
        public IReadOnlyCollection<IHit<Poetries>> poetries;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 索引连接
            var node = new Uri("http://127.0.0.1:9200");
            var settings = new ConnectionSettings(node).DefaultIndex("chinese-poetry");
            var client = new ElasticClient(settings);

            string keyword = Request.Form["keyword"];

            poetries = SearchPoetries(client, 1, 5, keyword);
        }

        public IReadOnlyCollection<IHit<Poetries>> SearchPoetries(ElasticClient Operator, int pageindex, int pagesize, string keyword)
        {
            // 添加关键字查询条件
            var shouldList = new List<Func<QueryContainerDescriptor<Poetries>, QueryContainer>>();
            if (!string.IsNullOrEmpty(keyword))
            {
                shouldList.Add(sh =>
                    sh.Match(sm => sm.Field(obj => obj.Content).Query(keyword)) ||
                    sh.Match(sm => sm.Field(obj => obj.Title).Query(keyword)));
            }

            // 组装查询表达式
            var searchResult = Operator.Search<Poetries>(s => s
               .Query(q => q
                   .Bool(b =>
                   {
                       if (shouldList != null && shouldList.Count > 0)
                       {
                           foreach (var shouldItem in shouldList)
                           {
                               b.Should(shouldItem);
                           }
                       }
                       return b;
                   })
               )
               // 添加高亮
               .Highlight(h => h
                    .Fields(
                        f => f
                            .Field(obj =>  obj.Content)
                            .PreTags("<span style=\"color: red\">")
                            .PostTags("</span>") ,
                        f => f
                            .Field(obj => obj.Title)
                            .PreTags("<span style=\"color: orange\">")
                            .PostTags("</span>")
                    )
               )
               // 分页
               .From((pageindex - 1) * pagesize)
               .Size(pagesize)
            );
            return searchResult.Hits;
        }
    }
}