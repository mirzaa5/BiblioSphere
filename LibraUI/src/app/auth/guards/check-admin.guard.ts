import { CanActivateFn } from '@angular/router';

export const checkAdminGuard: CanActivateFn = (route, state) => {
  
  let isAdmin = sessionStorage.getItem('isAdmin');
    if(isAdmin == "true")
    {
      return true
    }
  
    return false
};
