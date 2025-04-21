import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isLoggedIn = new Subject<boolean>();

  constructor() { 
    if(sessionStorage.getItem("token") != null)
    {
      this.isLoggedIn.next(true);
      console.log("emitting isLogged In behvaior subject")
      //.next conveys to all the subscribers of service fo change in Loggedin state.
      
    }
  }

  markUserAsLoggedIn()
  {
    this.isLoggedIn.next(true)
  }
}
