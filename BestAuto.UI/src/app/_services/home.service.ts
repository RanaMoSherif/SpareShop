import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HomeService {
  constructor() {}

  private subject: any = new Subject();
 
  sendMessage(message: any) {
      this.subject.next( message );
  }

  clearMessages() {
      this.subject.next();
  }

  getMessage(): Observable<any> {
      return this.subject.asObservable();
  }
  

}
