
namespace WarehouseManagementDesktopApp.Core.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        //private const string serverUrl = "http://192.168.1.13:8081";
        //private const string serverUrl = "https://hung-anh-storage-web-api.herokuapp.com";
        //private const string serverUrl = "https://storagewebapi20210714122113.azurewebsites.net";
        private const string serverUrl = "https://cha-warehouse-management.azurewebsites.net";
        private string token = "";
        public Action LoginCompleteAction { get; set; }
        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        //public async Task<ServiceResourceResponse<WarehouseEmployee>> LogInAsync(string username, string password)
        //{
        //    ServiceResourceResponse<WarehouseEmployee> result;

        //    var loginCredential = new LoginRequest(username, password);
        //    var json = JsonConvert.SerializeObject(loginCredential);

        //    try
        //    {
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        string url = $"{serverUrl}/api/auth";
        //        var response = await _httpClient.PostAsync(url, content);
        //        string responseBody = await response.Content.ReadAsStringAsync();

        //        switch (response.StatusCode)
        //        {
        //            case HttpStatusCode.OK:
        //                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

        //                token = loginResponse.Token.AuthToken;
        //                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        //                result = new ServiceResourceResponse<WarehouseEmployee>(loginResponse.Employee);
        //                return result;
        //            case HttpStatusCode.BadRequest:
        //                var error = new Error("Api.Login", "Tên đăng nhập hoặc mật khẩu không hợp lệ.");
        //                result = new ServiceResourceResponse<WarehouseEmployee>(error);
        //                return result;
        //            default:
        //                error = new Error("Api.Login", "Đã có lỗi xảy ra. Không thể thực hiện đăng nhập.");
        //                result = new ServiceResourceResponse<WarehouseEmployee>(error);
        //                return result;
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
        //        result = new ServiceResourceResponse<WarehouseEmployee>(error);
        //    }
        //    catch (Exception ex)
        //    {
        //        var error = new Error("Api.Login", "Đã có lỗi xảy ra. Không thể thực hiện đăng nhập.");
        //        result = new ServiceResourceResponse<WarehouseEmployee>(error);
        //        return result;
        //    }
        //    return result;
        //}
        public async Task<ServiceResponse> LogInAsync(string? token, Error error)
        {
            await Task.Delay(1);
            if (string.IsNullOrEmpty(error.Message))
            {
                this.token = token;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token);
                LoginCompleteAction?.Invoke();
                return ServiceResponse.Successful();
            }
            else
            {
                this.token = string.Empty;
                return ServiceResponse.Failed(error);
            }
        }
        public void LogOut()
        {
            token = "";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<ServiceResourceResponse<QueryResult<Product>>> GetAllProduct()
        {
            ServiceResourceResponse<QueryResult<Product>> result;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/items/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var product = JsonConvert.DeserializeObject<List<Product>>(responseBody);
#pragma warning disable CS8601 // Possible null reference assignment.
                        QueryResult<Product> queryResult = new QueryResult<Product> { Items = product };
#pragma warning restore CS8601 // Possible null reference assignment.
                        //var products = JsonConvert.DeserializeObject<QueryResult<Product>>(responseBody);
                        result = new ServiceResourceResponse<QueryResult<Product>>(queryResult);
                        return result;
                    default:
                        var error = new Error("Api.Product.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<QueryResult<Product>>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<QueryResult<Product>>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Product.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<QueryResult<Product>>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<Product>> GetProductbyId(string id)
        {
            ServiceResourceResponse<Product> result;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/items/{id}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var product = JsonConvert.DeserializeObject<Product>(responseBody);
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning restore CS8601 // Possible null reference assignment.
                        //var products = JsonConvert.DeserializeObject<QueryResult<Product>>(responseBody);
                        result = new ServiceResourceResponse<Product>(product);
                        return result;
                    default:
                        var error = new Error("Api.Product.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<Product>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<Product>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Product.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<Product>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResponse> PostNewProduct(NewProduct resource)
        {
            ServiceResponse result;
            var json = JsonConvert.SerializeObject(resource);
            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = $"{serverUrl}/api/items/";
                var response = await _httpClient.PostAsync(url, content);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return ServiceResponse.Successful();
                    case HttpStatusCode.BadRequest:
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var serverError = JsonConvert.DeserializeObject<ServerError>(responseBody);
                        var error = new Error("Api.Product.Post", serverError.Message);
                        return ServiceResponse.Failed(error);
                    case HttpStatusCode.Unauthorized:
                        error = new Error("Api.Product.Post", "Vui lòng đăng nhập.");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.Product.Post", "Đã có lỗi xảy ra.");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<Manager>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GoodsIssue.Post", "Đã có lỗi xảy ra. Không thể gửi dữ liệu về Server được.");
                result = ServiceResponse.Failed(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<QueryResult<Product>>> GetProductById(string productId)
        {
            ServiceResourceResponse<QueryResult<Product>> result;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/products/?stringInId=" + productId);
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var products = JsonConvert.DeserializeObject<QueryResult<Product>>(responseBody);
                        result = new ServiceResourceResponse<QueryResult<Product>>(products);
                        return result;
                    default:
                        var error = new Error("Api.Product.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<QueryResult<Product>>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<QueryResult<Product>>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Product.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<QueryResult<Product>>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<List<Container>>> GetContainerByProductId(string Id)
        {
            ServiceResourceResponse<List<Container>> result;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/containers?itemId=" + Id);
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var basket = JsonConvert.DeserializeObject<List<Container>>(responseBody);
                        result = new ServiceResourceResponse<List<Container>>(basket);
                        return result;
                    default:
                        var error = new Error("Api.Basket.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<List<Container>>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<List<Container>>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Basket.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<List<Container>>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResponse> PutBasket(string id, GoodsReceiptEntryPutAPI entry)
        {
            ServiceResponse result;
            var json = JsonConvert.SerializeObject(entry);
            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = $"{serverUrl}/api/baskets/" + id;
                var response = await _httpClient.PutAsync(url, content);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return ServiceResponse.Successful();
                    case HttpStatusCode.BadRequest:
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var serverError = JsonConvert.DeserializeObject<ServerError>(responseBody);
                        var error = new Error("Api.Basket.Put", serverError.Message);
                        return ServiceResponse.Failed(error);
                    case HttpStatusCode.Unauthorized:
                        error = new Error("Api.Basket.Put", "Vui lòng đăng nhập.");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.Basket.Put", "Đã có lỗi xảy ra.");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<Manager>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Basket.Put", "Đã có lỗi xảy ra. Không thể gửi dữ liệu về Server được.");
                result = ServiceResponse.Failed(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResponse> PostNewBasket(NewBasket newBasket)
        {
            ServiceResponse result;
            var json = JsonConvert.SerializeObject(newBasket);
            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = $"{serverUrl}/api/baskets/";
                var response = await _httpClient.PostAsync(url, content);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return ServiceResponse.Successful();
                    case HttpStatusCode.BadRequest:
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var serverError = JsonConvert.DeserializeObject<ServerError>(responseBody);
                        var error = new Error("Api.Basket.Post", serverError.Message);
                        return ServiceResponse.Failed(error);
                    case HttpStatusCode.Unauthorized:
                        error = new Error("Api.Basket.Post", "Vui lòng đăng nhập.");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.Basket.Post", "Đã có lỗi xảy ra.");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<Manager>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Basket.Post", $"Đã có lỗi xảy ra. Không thể gửi dữ liệu về Server được.");
                result = ServiceResponse.Failed(error);
                return result;
            }
            return result;
        }
        //public async Task<ServiceResponse> PostGoodsReceipts(GoodsReceiptPost resource)
        //{
        //    ServiceResponse result;
        //    var json = JsonConvert.SerializeObject(resource);
        //    try
        //    {
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");
        //        string url = $"{serverUrl}/api/goodsreceipts/";
        //        var response = await _httpClient.PostAsync(url, content);

        //        switch (response.StatusCode)
        //        {
        //            case HttpStatusCode.OK:
        //                return ServiceResponse.Successful();
        //            case HttpStatusCode.BadRequest:
        //                string responseBody = await response.Content.ReadAsStringAsync();
        //                var serverError = JsonConvert.DeserializeObject<ServerError>(responseBody);
        //                var error = new Error("Api.GoodsReceipts.Post", serverError.Message);
        //                return ServiceResponse.Failed(error);
        //            case HttpStatusCode.Unauthorized:
        //                error = new Error("Api.GoodsReceipts.Post", "Vui lòng đăng nhập.");
        //                return ServiceResponse.Failed(error);
        //            default:
        //                error = new Error("Api.GoodsReceiptse.Post", "Đã có lỗi xảy ra. Không thể Kết nối với Server.");
        //                return ServiceResponse.Failed(error);
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
        //        result = new ServiceResourceResponse<WarehouseEmployee>(error);
        //    }
        //    catch (Exception ex)
        //    {
        //        var error = new Error("Api.GoodsReceipts.Post", "Đã có lỗi xảy ra. Không thể gửi dữ liệu về Server được.");
        //        result = ServiceResponse.Failed(error);
        //        return result;
        //    }
        //    return result;
        //}
        public async Task<ServiceResponse> PostGoodsReceipts(GoodReceiptEntry resource)
        {
            ServiceResponse result;
            var json = JsonConvert.SerializeObject(resource);
            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = $"{serverUrl}/api/goodsreceipts/";
                var response = await _httpClient.PostAsync(url, content);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return ServiceResponse.Successful();
                    case HttpStatusCode.BadRequest:
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var serverError = JsonConvert.DeserializeObject<ServerError>(responseBody);
                        var error = new Error("Api.GoodsReceipts.Post", serverError.Message);
                        return ServiceResponse.Failed(error);
                    case HttpStatusCode.Unauthorized:
                        error = new Error("Api.GoodsReceipts.Post", "Vui lòng đăng nhập.");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.GoodsReceiptse.Post", "Đã có lỗi xảy ra. Không thể Kết nối với Server.");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<Manager>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GoodsReceipts.Post", "Đã có lỗi xảy ra. Không thể gửi dữ liệu về Server được.");
                result = ServiceResponse.Failed(error);
                return result;
            }
            return result;
        }
        // Location
        public async Task<ServiceResponse> PathSliceItem(string shelfId, int rowId, int cellId, int sliceId, string productId)
        {
            ServiceResponse result;
            var json = JsonConvert.SerializeObject(productId);
            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = $"{serverUrl}/api/shelves/{shelfId}/cells/{rowId}/{cellId}/slices/{sliceId}";
                var response = await _httpClient.PatchAsync(url, content);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return ServiceResponse.Successful();
                    case HttpStatusCode.BadRequest:
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var serverError = JsonConvert.DeserializeObject<ServerError>(responseBody);
                        var error = new Error("Api.GoodsReceipts.Post", serverError.Message);
                        return ServiceResponse.Failed(error);
                    case HttpStatusCode.Unauthorized:
                        error = new Error("Api.GoodsReceipts.Post", "Vui lòng đăng nhập.");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.GoodsReceiptse.Post", "Đã có lỗi xảy ra. Không thể Kết nối với Server.");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<Manager>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GoodsReceipts.Post", "Đã có lỗi xảy ra. Không thể gửi dữ liệu về Server được.");
                result = ServiceResponse.Failed(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<Cell>> GetCell(string shelfId,int rowId,int cellId)
        {
            ServiceResourceResponse<Cell> result;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/shelves/{shelfId}/cells/{rowId}/{cellId}");
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var cell = JsonConvert.DeserializeObject<Cell>(responseBody);
                        result = new ServiceResourceResponse<Cell>(cell);
                        return result;
                    default:
                        var error = new Error("Api.Shelf.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<Cell>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<Cell>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GetGoodsIssueById.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<Cell>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<Shelf>> GetShelf(string shelfId)
        {
            ServiceResourceResponse<Shelf> result;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/shelves/" + shelfId);
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var products = JsonConvert.DeserializeObject<Shelf>(responseBody);
                        result = new ServiceResourceResponse<Shelf>(products);
                        return result;
                    default:
                        var error = new Error("Api.Shelf.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<Shelf>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<Shelf>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GetGoodsIssueById.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<Shelf>(error);
                return result;
            }
            return result;
        }
        // GoodIssue
        public async Task<ServiceResponse> PostGoodsIssue(GoodIssueEntry resource)
        {
            ServiceResponse result;
            var json = JsonConvert.SerializeObject(resource);
            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = $"{serverUrl}/api/goodsissues/";
                var response = await _httpClient.PostAsync(url, content);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return ServiceResponse.Successful();
                    case HttpStatusCode.BadRequest:
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var serverError = JsonConvert.DeserializeObject<ServerError>(responseBody);
                        var error = new Error("Api.GoodsIssue.Post", serverError.Message);
                        return ServiceResponse.Failed(error);
                    case HttpStatusCode.Unauthorized:
                        error = new Error("Api.GoodsIssue.Post", "Vui lòng đăng nhập.");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.GoodsIssue.Post", "Đã có lỗi xảy ra.");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<Manager>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GoodsIssue.Post", "Đã có lỗi xảy ra. Không thể gửi dữ liệu về Server được.");
                result = ServiceResponse.Failed(error);
                return result;
            }
            return result;
        }

        public async Task<ServiceResponse> PatchGoodsIssueEntryContainer(List<IssueEntryContainer> resource, string goodsIssueId)
        {
            ServiceResponse result;
            //var httpRequestMessage = new HttpRequestMessage
            //{
            //    Method = new HttpMethod("PATCH"),
            //    RequestUri = new Uri(serverUrl + $"/api/goodsissues/"+ goodsIssueId + "/containers"),
            //    Content = new StringContent(JsonConvert.SerializeObject(resource), Encoding.UTF8, "application/json")
            //};
            //httpRequestMessage.Headers.Add("Authorization", "Bearer " + token);
            //var r = await httpRequestMessage.Content.ReadAsStringAsync();
            //var response = await _httpClient.SendAsync(httpRequestMessage);

            var json = JsonConvert.SerializeObject(resource);
            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = $"{serverUrl}/api/goodsissues/{goodsIssueId}/containers";
                var response = await _httpClient.PatchAsync(url, content);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return ServiceResponse.Successful();
                    case HttpStatusCode.BadRequest:
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var serverError = JsonConvert.DeserializeObject<ServerError>(responseBody);
                        var error = new Error("Api.GoodsIssueEntryBasket.Patch", serverError.Detail);
                        return ServiceResponse.Failed(error);
                    case HttpStatusCode.Unauthorized:
                        error = new Error("Api.GoodsIssueEntryBasket.Patch", "Vui lòng đăng nhập.");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.GoodsIssueEntryBasket.Patch", "Đã có lỗi xảy ra.");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra. Không thể kết nối được với server vì: {ex.Message}");
                result = new ServiceResourceResponse<Manager>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GoodsIssue.Post", $"Đã có lỗi xảy ra. Không thể gửi dữ liệu về server được vì: {ex.Message}");
                result = ServiceResponse.Failed(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<GoodsIssueById>> GetGoodsIssueById(string goodsIssueId)
        {
            ServiceResourceResponse<GoodsIssueById> result;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/goodsissues/" + goodsIssueId);
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var products = JsonConvert.DeserializeObject<GoodsIssueById>(responseBody);
                        result = new ServiceResourceResponse<GoodsIssueById>(products);
                        return result;
                    default:
                        var error = new Error("Api.GetGoodsIssueById.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<GoodsIssueById>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<GoodsIssueById>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GetGoodsIssueById.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<GoodsIssueById>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<GoodIssueFromServer>> GetGoodsIssueByTime(DateTime date)
        {
            ServiceResourceResponse<GoodIssueFromServer> result;
            string startDateString = date.AddDays(-3).ToString("yyyy-MM-dd");
            string endDateString = date.AddDays(5).ToString("yyyy-MM-dd");
            try
            {
                var url = $"{serverUrl}/api/goodsissues/?Page=1&ItemsPerPage=10&StartTime={startDateString}&EndTime={endDateString}";
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/goodsissues/?Page=1&ItemsPerPage=10&StartTime={startDateString}&EndTime={endDateString}");
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var products = JsonConvert.DeserializeObject<GoodIssueFromServer>(responseBody);
                        result = new ServiceResourceResponse<GoodIssueFromServer>(products);
                        return result;
                    default:
                        var error = new Error("Api.GetGoodsIssueByTime.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<GoodIssueFromServer>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<GoodIssueFromServer>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GetGoodsIssueByTime.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<GoodIssueFromServer>(error);
                return result;
            }
            return result;
        }

        public async Task<ServiceResourceResponse<IEnumerable<StorageSlot>>> GetStorageID()
        {
            ServiceResourceResponse<IEnumerable<StorageSlot>> result;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/storageslots/");
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var storageId = JsonConvert.DeserializeObject<IEnumerable<StorageSlot>>(responseBody);
                        result = new ServiceResourceResponse<IEnumerable<StorageSlot>>(storageId);
                        return result;
                    default:
                        var error = new Error("Api.StorageId.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<IEnumerable<StorageSlot>>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<IEnumerable<StorageSlot>>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.StorageId.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<IEnumerable<StorageSlot>>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<List<Stockcardentries>>> GetAllStockCard(DateTime? startTime, DateTime? stopTime, string product)
        {
            ServiceResourceResponse<List<Stockcardentries>> result;
            string starttimequery = "";
            string stoptimequery = "";

            if (startTime != null && product != null)
            {
                starttimequery = startTime.Value.ToString("yyyy-MM-dd");
                stoptimequery = stopTime.Value.ToString("yyyy-MM-dd");
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/stockcardentries/?StartTime=" + starttimequery + "&EndTime=" + stoptimequery + "&ItemId=" + product);
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var stockCards = JsonConvert.DeserializeObject<List<Stockcardentries>>(responseBody);
                        result = new ServiceResourceResponse<List<Stockcardentries>>(stockCards);
                        return result;
                    default:
                        var error = new Error("Api.GetAllStockCard.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<List<Stockcardentries>>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<List<Stockcardentries>>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GetAllStockCard.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<List<Stockcardentries>>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<GoodReceiptReport>> GetGoodsReceipt(DateTime startTime, DateTime stopTime)
        {
            ServiceResourceResponse<GoodReceiptReport> result;

            string startDateString = startTime.ToString("yyyy-MM-dd");
            string endDateString = stopTime.AddDays(1).ToString("yyyy-MM-dd");
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/goodsreceipts/?Page=1&ItemsPerPage=100&StartTime={startDateString}&EndTime={endDateString}");
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var goodsReceipt = JsonConvert.DeserializeObject<GoodReceiptReport>(responseBody);
                        result = new ServiceResourceResponse<GoodReceiptReport>(goodsReceipt);
                        return result;
                    default:
                        var error = new Error("Api.GetGoodsReceipt.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<GoodReceiptReport>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<GoodReceiptReport>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GetGoodsReceipt.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<GoodReceiptReport>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<GoodExportReport>> GetGoodsIssue(DateTime startTime, DateTime stopTime)
        {
            ServiceResourceResponse<GoodExportReport> result;

            string startDateString = startTime.ToString("yyyy-MM-dd");
            string endDateString = stopTime.AddDays(1).ToString("yyyy-MM-dd");
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/goodsissues/?Page=1&ItemsPerPage=10&StartTime={startDateString}&EndTime={ endDateString}");
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var goodsIssue = JsonConvert.DeserializeObject<GoodExportReport>(responseBody);
                        result = new ServiceResourceResponse<GoodExportReport>(goodsIssue);
                        return result;
                    default:
                        var error = new Error("Api.GetGoodsIssue.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<GoodExportReport>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<GoodExportReport>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GetGoodsIssue.Get", $"Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<GoodExportReport>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<GoodReceiptReport>> GetUnfinishedGoodsReceipt(DateTime startTime, DateTime stopTime)
        {
            ServiceResourceResponse<GoodReceiptReport> result;

            string startDateString = startTime.ToString("yyyy-MM-dd");
            string endDateString = stopTime.AddDays(1).ToString("yyyy-MM-dd");
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/goodsreceipts/?Page=1&ItemsPerPage=100&StartTime={startDateString}&EndTime={endDateString}");
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var goodsReceipt = JsonConvert.DeserializeObject<GoodReceiptReport>(responseBody);
                        var unfinisheddata = goodsReceipt.items.Where(s => s.confirmed == false).ToList();

                        result = new ServiceResourceResponse<GoodReceiptReport>(goodsReceipt);
                        return result;
                    default:
                        var error = new Error("Api.GetGoodsReceipt.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<GoodReceiptReport>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<GoodReceiptReport>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.GetGoodsReceipt.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<GoodReceiptReport>(error);
                return result;
            }
            return result;
        }

        public async Task<ServiceResourceResponse<List<BasketInconsistency>>> GetUnfixedInconsistencies()
        {
            ServiceResourceResponse<List<BasketInconsistency>> result;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/baskets/inconsistencies/unfixed/?Page=1&ItemsPerPage=100");
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var basket = JsonConvert.DeserializeObject<List<BasketInconsistency>>(responseBody);
                        result = new ServiceResourceResponse<List<BasketInconsistency>>(basket);
                        return result;
                    default:
                        var error = new Error("Api.BasketInconsistency.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<List<BasketInconsistency>>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<List<BasketInconsistency>>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.BasketInconsistency.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<List<BasketInconsistency>>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<QueryResult<BasketInconsistency>>> GetListOfUnconsistencies(DateTime startTime, DateTime stopTime)
        {
            ServiceResourceResponse<QueryResult<BasketInconsistency>> result;
            string startDateString = startTime.AddDays(-1).ToString("yyyy-MM-dd");
            string endDateString = stopTime.AddDays(1).ToString("yyyy-MM-dd");
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/baskets/inconsistencies/?Page=1&ItemsPerPage=1000&StartTime={startDateString}&StopTime={ endDateString}");
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var basket = JsonConvert.DeserializeObject<QueryResult<BasketInconsistency>>(responseBody);
                        result = new ServiceResourceResponse<QueryResult<BasketInconsistency>>(basket);
                        return result;
                    default:
                        var error = new Error("Api.ListOfUnconsistencies.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<QueryResult<BasketInconsistency>>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", "Đã có lỗi xảy ra. Không thể kết nối được với Server.");
                result = new ServiceResourceResponse<QueryResult<BasketInconsistency>>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.ListOfUnconsistencies.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ Server.");
                result = new ServiceResourceResponse<QueryResult<BasketInconsistency>>(error);
                return result;
            }
            return result;
        }
    }
}
