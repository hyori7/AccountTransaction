using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using System.IO;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Version = Lucene.Net.Util.Version;

namespace Logical
{
    public class Lucene_lg
    {

        public void addLucene(Data data)
        {
            User_lg user = new User_lg();
            Data list = user.luceneSelect(data);
            Lucene.Net.Store.Directory directory = FSDirectory.Open(new DirectoryInfo("C:\\Visual Studio 2010\\Transaction" + "\\LuceneIndex"));
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED);
            for (int i = 0; i < list.Count; i++)
            {
                Document document = new Document();
                document.Add(new Field("id", list.getValue(i, "id").ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                document.Add(new Field("name", list.getValue(i, "name").ToString(), Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS));
                document.Add(new Field("username", list.getValue(i, "username").ToString(), Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS));
                writer.AddDocument(document);
                writer.Optimize();
                writer.Commit();
            }
            writer.Dispose();
        }

        public Data searchLucene(Data data)
        {
            Account_lg account = new Account_lg();
            List<string> item = new List<string>();
            Lucene.Net.Store.Directory directory = FSDirectory.Open(new DirectoryInfo("C:\\Visual Studio 2010\\Transaction" + "\\LuceneIndex"));
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);

            MultiFieldQueryParser parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_29, new string[] { "name", "username" }, analyzer);  //search for multifield
            Query query = parser.Parse((data.getString("search")) + "*"); //cant search blank text with wildcard as first character

            TopScoreDocCollector collector = TopScoreDocCollector.Create(1000, true);
            searcher.Search(query, collector);
            ScoreDoc[] hits = collector.TopDocs().ScoreDocs;
            int count = hits.Length;


            for (int i = 0; i < count; i++)
            {
                int docId = hits[i].Doc;
                float score = hits[i].Score;

                Document doc = searcher.Doc(docId);

                string id = doc.Get("id");
                item.Add(id);
            }
            Data list = account.selectUser(data, item.ToArray());
            reader.Dispose();
            searcher.Dispose();

            return list;
        }
    }
}
