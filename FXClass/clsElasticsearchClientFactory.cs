using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWorxServer
{
    public class clsElasticsearchClientFactory
    {
        private readonly ElasticsearchClientSettings _settings;
        public clsElasticsearchClientFactory()
        {
            _settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
                .CertificateFingerprint("c4fa65e2777caca232b98afba1116ac030c3312c741d9d0fbfa85ed6be9531a2")
                .Authentication(new BasicAuthentication("elastic", "BjN4ppWzlAPnHLZMkC3J"));
        }
        public clsElasticsearchClientFactory(string defaultIndex)
        {
            _settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
                .CertificateFingerprint("c4fa65e2777caca232b98afba1116ac030c3312c741d9d0fbfa85ed6be9531a2")
                .Authentication(new BasicAuthentication("elastic", "BjN4ppWzlAPnHLZMkC3J"))
                .DefaultIndex(defaultIndex);
        }
        public ElasticsearchClient CreateClient()
        {
            return new ElasticsearchClient(_settings);
        }
    }
}
