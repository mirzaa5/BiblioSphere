import { inject, Inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  
  const router = inject(Router);

  const token = sessionStorage.getItem('token');
  if(!token)
  {
    // alert("Authguard Worked");
    // window.location.href='/login';
    router.navigate(['/login']);
    return false
  }
  return true;
};
