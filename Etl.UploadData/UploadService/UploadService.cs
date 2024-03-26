using Etl.DataAccess.Postgres.Repository;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System;
using Etl.DataAccess.Postgres.Model;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using Etl.UploadData.Model;
using System.Xml.Linq;
using System.Collections.Concurrent;
using System.Threading;
using System.Diagnostics;

namespace Etl.UploadData.UploadService
{
    public class UploadService : IUploadService
    {
        private readonly IUniversitetsRepository _universityRepository;
        private readonly IDomainRepository _domainsRepository;
        private readonly IWebPageRepository _webPageRepository;
        private int _initCount = 1;
        private int _maxCount = 1;

        Semaphore semaphore;

        Thread thread;


        public UploadService(IUniversitetsRepository universityRepository, IDomainRepository domainRepository, IWebPageRepository webPageRepository)
        {
            _universityRepository = universityRepository;
            _domainsRepository = domainRepository;
            _webPageRepository = webPageRepository;
        }


        public void Init(int initCount, int maxCount, string nameThread)
        {
            _initCount = initCount;
            _maxCount = maxCount;
            semaphore =  new Semaphore(initCount, maxCount);

        }

        public async IAsyncEnumerable<UniversitetEntity?> UploadData(Uri uri, Dictionary<string, string> parameters)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var urlParams = "?" + string.Join("&", parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
                httpClient.BaseAddress = uri;
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync(urlParams).Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadFromJsonAsAsyncEnumerable<UniversitetApiModel>();

                    await foreach (var item in data)
                    {
                        var temp = new UniversitetEntity()
                        {
                            Name = item.Name,
                            StateProvince = item.StateProvince,
                            Country = item.Country,
                            AphaTwoCode = item.AphaTwoCode,
                            domainEntities = item.domains.Select(q => new DomainEntity() { Domain = q }).ToList(),
                            webPageEntities = item.webPages.Select(q => new WebPageEntity() { Name = q }).ToList()
                        };

                        await _universityRepository.AddAsync(temp);
                        yield return temp;
                    }
                }

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<UniversitetEntity?> UploadData2(Uri uri, ConcurrentDictionary<string, string> parameters)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var urlParams = "?" + string.Join("&", parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
                httpClient.BaseAddress = uri;
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync(urlParams).Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadFromJsonAsAsyncEnumerable<UniversitetApiModel>();

                    await foreach (var item in data)
                    {
                        var temp = new UniversitetEntity()
                        {
                            Name = item.Name,
                            StateProvince = item.StateProvince,
                            Country = item.Country,
                            AphaTwoCode = item.AphaTwoCode,
                            domainEntities = item.domains.Select(q => new DomainEntity() { Domain = q }).ToList(),
                            webPageEntities = item.webPages.Select(q => new WebPageEntity() { Name = q }).ToList()
                        };

                        await _universityRepository.AddAsync(temp);
                        yield return temp;
                    }



                    //await foreach (var entity in data)
                    //{
                    //    yield return entity;
                    //}
                }

            }
        }

        public void UploadDataNoReturn(Uri uri, Dictionary<string, string> parameters)
        {
            string name = parameters["country"] ?? "unknow";
            thread = new Thread(async () =>
            {
                semaphore.WaitOne();

                using (HttpClient httpClient = new HttpClient())
                {
                    var urlParams = "?" + string.Join("&", parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
                    httpClient.BaseAddress = uri;
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = httpClient.GetAsync(urlParams).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadFromJsonAsAsyncEnumerable<UniversitetApiModel>();

                        await foreach (var item in data)
                        {
                            var temp = new UniversitetEntity()
                            {
                                Name = item.Name,
                                StateProvince = item.StateProvince,
                                Country = item.Country,
                                AphaTwoCode = item.AphaTwoCode,
                                domainEntities = item.domains.Select(q => new DomainEntity() { Domain = q }).ToList(),
                                webPageEntities = item.webPages.Select(q => new WebPageEntity() { Name = q }).ToList()
                            };

                            await _universityRepository.AddAsync(temp);
                        }
                    }

                }

                semaphore.Release();
            });
            thread.Name = name;
            thread.Start();

        }
    }
}


/*
                 using (HttpClient httpClient = new HttpClient())
                {
                    var urlParams = "?" + string.Join("&", parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
                    httpClient.BaseAddress = uri;
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = httpClient.GetAsync(urlParams).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadFromJsonAsAsyncEnumerable<UniversitetApiModel>();

                        await foreach (var item in data)
                        {
                            var temp = new UniversitetEntity()
                            {
                                Name = item.Name,
                                StateProvince = item.StateProvince,
                                Country = item.Country,
                                AphaTwoCode = item.AphaTwoCode,
                                domainEntities = item.domains.Select(q => new DomainEntity() { Domain = q }).ToList(),
                                webPageEntities = item.webPages.Select(q => new WebPageEntity() { Name = q }).ToList()
                            };

                            await _universityRepository.AddAsync(temp);
                        }
                    }

                }
 */