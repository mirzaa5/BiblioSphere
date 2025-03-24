import { HttpInterceptorFn } from '@angular/common/http';

export const tokenInterceptor: HttpInterceptorFn = (req, next) => {

 console.log("interceptor")
  let token = sessionStorage.getItem("token");
    if(token)
    {
      console.log(sessionStorage.getItem("token")); // Debug

      req = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + token)
      });  
    }

  return next(req);
};
