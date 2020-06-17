# Web API Authentication With Custom Action Filters

Web API includes filters to add extra logic before or after action method executes. Filters can be used to provide cross-cutting features such as logging, exception handling, performance measurement, authentication and authorization.

For this demo we will be creating 3 custom classes which will be derieved from ActionFilterAttribute and they are as follows,

- AuthenticateWithApiKey.cs
- AuthenticateWithJwt.cs
- AuthenticateWithLdap.cs

We will override OnActionExecuting method to write our custom logic.

**AuthenticateWithApiKey**

