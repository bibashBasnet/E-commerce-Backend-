<h1>Initial process</h1>
<h3>git clone https://github.com/bibashBasnet/E-commerce-Backend-.git</h3>
<h3>cd E-commerce-Backend and cd E-commerce</h3>
<h3>dotnet restore</h3>

<h1>Configuration</h1>
<h3>Configure the connecting string inside the appsettings.json</h3>

<h1>To run</h1>
<h3>dotnet ef migrations add "anything"</h3>
<h3>dotnet ef database update</h3>
<h3>dotnet build</h3>
<h3>dotnet run</h3>

<h1>Api EndPoint</h1>
<h2>Product</h2>
<h3>Get /api/Product/getAllProduct:- To get all the product of db</h3>
<h3>Get /api/Product/getProductById/{id}:- To get a certain product with id</h3>
<h3>Post /api/Product/createProduct:- To create a new product</h3>
<h4>body = {
    "productName": string,
    "productPrice": float,
    "productQuantity": int
}</h4>
<h3>Delete /api/Product/deleteProduct/{id}:- To delete a product using id of that product</h3>
<h3>Put /api/Product/updateProduct/{id}:- To update the content of a certain product using the id of that product.</h3>
<h4>body = {
        "productName": string,
        "productPrice": float,
        "productQuantity": int
}</h4>
<h2>User</h2>
<h3>Get /api/User/getAllUser:- To get all the user of db</h3>
<h3>Get /api/User/getUserById/{id}:- To get the certain user with id</h3>
<h3>Post /api/User/create:- To create a new user.</h3>
<h4>{
    "Name": string,
    "DOB": year-month-day,
    "Phone": string,
    "UserName": string,
    "Password": string
}</h4>
<h3>Delete /api/User/deleteUser/{id}:- Delete a user with id</h3>
<h3>Put /api/User/update/{id}:- Update the value of user with id</h3>
<h4>body = {
    "name": string,
    "dob": year-month-day,
    "phone": string
}</h4>
<h2>Order</h2>
<h3>Get /api/Order/getAllOrders:- To get all the orders from the db</h3>
<h3>Get /api/Order/getOrderById/{id}:- To get certain order from db with id</h3>
<h3>Post /api/Order/createOrder:- To create a new order</h3>
<h4>body = {
        "ProductId": int,
        "quantity": int,
        "total": float,
        "UserId": int
}</h4>
<h3>Delete /api/Order/deleteOrder/{id}:- Delete a order with id.</h3>
<h3>Put /api/Order/updateOrder/{id}:- Update a order with id.</h3>
<h4>body = {
    "quantity": int,
    "total": float
}</h4>

