import { CanActivateFn } from '@angular/router';

export const checkAdminGuard: CanActivateFn = (route, state) => {
  
  let isAdmin = sessionStorage.getItem('isAdmin');
    if(isAdmin == "true")
    {
      alert("Is admin guard triggered");
      return true
    }
  
    return false
};
