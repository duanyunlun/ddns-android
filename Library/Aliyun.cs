using AlibabaCloud.OpenApiClient.Models;
using AlibabaCloud.SDK.Alidns20150109;
using AlibabaCloud.SDK.Alidns20150109.Models;
using AlibabaCloud.TeaUtil.Models;

using CloudKit;

namespace DDNS.Library
{
    public class AliyunApi
    {
        /// <summary>
        /// 临时缓存
        /// </summary>
        private static Dictionary<string, Client> clientCache = new Dictionary<string, Client>();

        /// <summary>
        /// 根据accessKeyId和accessKeySecret创建aliyunddns客户端
        /// </summary>
        /// <param name="accessKeyId"></param>
        /// <param name="accessKeySecret"></param>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        public static Client CreateClient(string accessKeyId, string accessKeySecret, string endPoint = "alidns.cn-shenzhen.aliyuncs.com")
        {
            Config config = new Config
            {
                AccessKeyId = accessKeyId,
                AccessKeySecret = accessKeySecret,
                Endpoint = endPoint
            };
            return CreateClient(config);
        }

        /// <summary>
        /// 创建aliyunddns客户端
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static Client CreateClient(Config config)
        {
            if (string.IsNullOrEmpty(config.AccessKeyId) || string.IsNullOrEmpty(config.AccessKeySecret))
                return clientCache.FirstOrDefault().Value;

            if (!clientCache.ContainsKey(config.AccessKeyId))
            {
                clientCache.Add(config.AccessKeyId, new Client(config));
            }
            return clientCache[config.AccessKeyId];
        }

        /// <summary>
        /// 根据传入参数获取指定主域名的所有解析记录列表
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static DescribeDomainRecordsResponseBody GetDomainRecords(Client client, DescribeDomainRecordsRequest request)
        {
            RuntimeOptions runtime = new RuntimeOptions();
            var result = client.DescribeDomainRecordsWithOptions(request, runtime);
            return result.Body;
        }

        /// <summary>
        /// 根据传入参数获取指定主域名的所有解析记录列表
        /// </summary>
        /// <param name="client"></param>
        /// <param name="domainName"></param>
        /// <returns></returns>
        public static DescribeDomainRecordsResponseBody GetDomainRecords(Client client, string domainName)
        {
            DescribeDomainRecordsRequest request = new DescribeDomainRecordsRequest
            {
                DomainName = domainName,
            };
            return GetDomainRecords(client, request);
        }

        /// <summary>
        /// 根据传入参数获取某个固定子域名的所有解析记录列表
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static DescribeSubDomainRecordsResponseBody GetSubDomainRecords(Client client, DescribeSubDomainRecordsRequest request)
        {
            RuntimeOptions runtime = new RuntimeOptions();
            var result = client.DescribeSubDomainRecordsWithOptions(request, runtime);
            return result.Body;
        }

        /// <summary>
        /// 根据传入参数获取某个固定子域名的所有解析记录列表
        /// </summary>
        /// <param name="client"></param>
        /// <param name="subDomain"></param>
        /// <returns></returns>
        public static DescribeSubDomainRecordsResponseBody GetSubDomainRecords(Client client, string subDomain)
        {
            DescribeSubDomainRecordsRequest request = new DescribeSubDomainRecordsRequest
            {
                SubDomain = subDomain,
            };
            return GetSubDomainRecords(client, request);
        }

        /// <summary>
        /// 根据传入参数获取某个固定子域名的所有解析记录列表
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static DescribeDomainRecordInfoResponseBody GetDomainRecordInfo(Client client, DescribeDomainRecordInfoRequest request)
        {
            RuntimeOptions runtime = new RuntimeOptions();
            var result = client.DescribeDomainRecordInfoWithOptions(request, runtime);
            return result.Body;
        }

        /// <summary>
        /// 根据传入参数获取某个固定子域名的所有解析记录列表
        /// </summary>
        /// <param name="client"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public static DescribeDomainRecordInfoResponseBody GetDomainRecordInfo(Client client, string recordId)
        {
            DescribeDomainRecordInfoRequest request = new DescribeDomainRecordInfoRequest
            {
                RecordId = recordId,
            };
            return GetDomainRecordInfo(client, request);
        }

        /// <summary>
        /// 根据传入参数获取域名的解析操作日志
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static DescribeRecordLogsResponseBody GetRecordLogs(Client client, DescribeRecordLogsRequest request)
        {
            RuntimeOptions runtime = new RuntimeOptions();
            var result = client.DescribeRecordLogsWithOptions(request, runtime);
            return result.Body;
        }

        /// <summary>
        /// 根据传入参数获取域名的解析操作日志
        /// </summary>
        /// <param name="client"></param>
        /// <param name="domainName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DescribeRecordLogsResponseBody GetRecordLogs(Client client, string domainName, string type)
        {
            DescribeRecordLogsRequest request = new DescribeRecordLogsRequest
            {
                DomainName = domainName,
            };
            return GetRecordLogs(client, request);
        }

        /// <summary>
        /// 生成txt记录。用于域名、子域名找回、添加子域名验证、批量找回等功能
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static GetTxtRecordForVerifyResponseBody GetTxtRecordForVerify(Client client, GetTxtRecordForVerifyRequest request)
        {
            RuntimeOptions runtime = new RuntimeOptions();
            var result = client.GetTxtRecordForVerifyWithOptions(request, runtime);
            return result.Body;
        }

        /// <summary>
        /// 生成txt记录。用于域名、子域名找回、添加子域名验证、批量找回等功能
        /// </summary>
        /// <param name="client"></param>
        /// <param name="domainName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static GetTxtRecordForVerifyResponseBody GetTxtRecordForVerify(Client client, string domainName, string type)
        {
            GetTxtRecordForVerifyRequest request = new GetTxtRecordForVerifyRequest
            {
                DomainName = domainName,
                Type = type
            };
            return GetTxtRecordForVerify(client, request);
        }

        /// <summary>
        /// 根据传入参数添加解析记录
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static AddDomainRecordResponseBody AddDomainRecord(Client client, AddDomainRecordRequest request)
        {
            RuntimeOptions runtime = new RuntimeOptions();
            var result = client.AddDomainRecordWithOptions(request, runtime);
            return result.Body;
        }

        /// <summary>
        /// 根据传入参数添加解析记录
        /// </summary>
        /// <param name="client"></param>
        /// <param name="domainName"></param>
        /// <param name="rr"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="ttl"></param>
        /// <returns></returns>
        public static AddDomainRecordResponseBody AddDomainRecord(Client client, string domainName, string rr, string type, string value, int ttl = 600)
        {
            AddDomainRecordRequest request = new AddDomainRecordRequest
            {
                DomainName = domainName,
                RR = rr,
                Type = type,
                Value = value,
                TTL = ttl
            };
            return AddDomainRecord(client, request);
        }

        /// <summary>
        /// 根据传入参数修改解析记录
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static UpdateDomainRecordResponseBody UpdateDomainRecord(Client client, UpdateDomainRecordRequest request)
        {
            RuntimeOptions runtime = new RuntimeOptions();
            var result = client.UpdateDomainRecordWithOptions(request, runtime);
            return result.Body;
        }

        /// <summary>
        /// 根据传入参数修改解析记录
        /// </summary>
        /// <param name="client"></param>
        /// <param name="recordId"></param>
        /// <param name="rr"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="ttl"></param>
        /// <returns></returns>
        public static UpdateDomainRecordResponseBody UpdateDomainRecord(Client client, string recordId, string rr, string type, string value, int ttl = 600)
        {
            UpdateDomainRecordRequest request = new UpdateDomainRecordRequest
            {
                RecordId = recordId,
                RR = rr,
                Type = type,
                Value = value,
                TTL = ttl
            };
            return UpdateDomainRecord(client, request);
        }

        /// <summary>
        /// 根据传入参数修改解析记录的备注
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static UpdateDomainRecordRemarkResponseBody UpdateDomainRecordRemark(Client client, UpdateDomainRecordRemarkRequest request)
        {
            RuntimeOptions runtime = new RuntimeOptions();
            var result = client.UpdateDomainRecordRemarkWithOptions(request, runtime);
            return result.Body;
        }

        /// <summary>
        /// 根据传入参数修改解析记录的备注
        /// </summary>
        /// <param name="client"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public static UpdateDomainRecordRemarkResponseBody UpdateDomainRecordRemark(Client client, string recordId)
        {
            UpdateDomainRecordRemarkRequest request = new UpdateDomainRecordRemarkRequest
            {
                RecordId = recordId,
            };
            return UpdateDomainRecordRemark(client, request);
        }

        /// <summary>
        /// 根据传入参数设置解析记录状态
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static SetDomainRecordStatusResponseBody UpdateDomainRecordStatus(Client client, SetDomainRecordStatusRequest request)
        {
            RuntimeOptions runtime = new RuntimeOptions();
            var result = client.SetDomainRecordStatusWithOptions(request, runtime);
            return result.Body;
        }

        /// <summary>
        /// 根据传入参数设置解析记录状态
        /// </summary>
        /// <param name="client"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public static SetDomainRecordStatusResponseBody UpdateDomainRecordStatus(Client client, string recordId)
        {
            SetDomainRecordStatusRequest request = new SetDomainRecordStatusRequest
            {
                RecordId = recordId,
            };
            return UpdateDomainRecordStatus(client, request);
        }

        /// <summary>
        /// 根据传入参数删除解析记录
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static DeleteDomainRecordResponseBody DeleteDomainRecord(Client client, DeleteDomainRecordRequest request)
        {
            RuntimeOptions runtime = new RuntimeOptions();
            var result = client.DeleteDomainRecordWithOptions(request, runtime);
            return result.Body;
        }

        /// <summary>
        /// 根据传入参数删除解析记录
        /// </summary>
        /// <param name="client"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public static DeleteDomainRecordResponseBody DeleteDomainRecord(Client client, string recordId)
        {
            DeleteDomainRecordRequest request = new DeleteDomainRecordRequest
            {
                RecordId = recordId,
            };
            return DeleteDomainRecord(client, request);
        }

        /// <summary>
        /// 根据传入参数删除主机记录对应的解析记录
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static DeleteSubDomainRecordsResponseBody DeleteSubDomainRecords(Client client, DeleteSubDomainRecordsRequest request)
        {
            RuntimeOptions runtime = new RuntimeOptions();
            var result = client.DeleteSubDomainRecordsWithOptions(request, runtime);
            return result.Body;
        }

        /// <summary>
        /// 根据传入参数删除主机记录对应的解析记录
        /// </summary>
        /// <param name="client"></param>
        /// <param name="domainName"></param>
        /// <param name="rr"></param>
        /// <returns></returns>
        public static DeleteSubDomainRecordsResponseBody DeleteSubDomainRecords(Client client, string domainName, string rr)
        {
            DeleteSubDomainRecordsRequest request = new DeleteSubDomainRecordsRequest
            {
                DomainName = domainName,
                RR = rr
            };
            return DeleteSubDomainRecords(client, request);
        }
    }
}
