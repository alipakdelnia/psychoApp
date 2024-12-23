import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class mainInterceptorInterceptor implements HttpInterceptor{
 
  private readonly baseUrl = 'http://localhost:5087/';

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
// if(req.url.startsWith('http')){
//   return next.handle(req);
//   }

  const apiReq = req.clone({
    url: `${this.baseUrl}${req.url}`,
  });

  return next.handle(apiReq);
  
}
}