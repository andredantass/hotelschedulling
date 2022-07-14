import { BehaviorSubject, Subject } from "rxjs";
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
  })
export class SharedDataService {
    constructor(){}

    public policyCutomerData: any = null;
    public subject = new Subject<any>();
    private messageSource = new  BehaviorSubject(this.policyCutomerData);
    currentMessage = this.messageSource.asObservable();

    // tslint:disable-next-line:typedef
    passCustomerPolicyData(policyCutomerData: any) {
        this.messageSource.next(policyCutomerData);
    }
}
