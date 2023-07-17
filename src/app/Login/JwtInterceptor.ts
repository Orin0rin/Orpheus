import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Get the JWT cookie
    const jwtCookie = this.getCookie('jwt');

    // If the JWT cookie exists, add it to the request headers
    if (jwtCookie) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${jwtCookie}`
        }
      });
    }

    return next.handle(request);
  }

  private getCookie(name: string): string|undefined {
    const cookieValue = document.cookie.match('(^|;)\\s*' + name + '\\s*=\\s*([^;]+)');
    return cookieValue ? cookieValue.pop() : '';
  }
}
