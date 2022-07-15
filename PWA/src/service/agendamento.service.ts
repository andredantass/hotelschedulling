import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from "rxjs";
import { environment } from "src/environments/environment";
import { ReservationRequest } from "src/app/agendamento/model/Reservation";
import { catchError } from 'rxjs/operators';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  };

@Injectable({
    providedIn:'root'
})
export class ReservationService
{
    errorMsg;
    baseURL = environment.urlBase;
    constructor(private httpClient:HttpClient){

    }

    insert(data:ReservationRequest): Observable<any>{
        return this.httpClient.post(`${this.baseURL}/reservation`, data, httpOptions)
        .pipe(catchError(error => {
            this.errorMsg = error.message;
            return of([]);
        }));
    }
    update(data:ReservationRequest): Observable<any>{
        return this.httpClient.put(`${this.baseURL}/reservation`, data, httpOptions)
        .pipe(catchError(error => {
            this.errorMsg = error.message;
            return of([]);
        }));
    }
    cancel(id:number): Observable<any>{
        return this.httpClient.delete(`${this.baseURL}/reservation/${id}`)
        .pipe(catchError(error => {
            this.errorMsg = error.message;
            return of([]);
        }));
    }
    select(): Observable<any>{
        return this.httpClient.get(`${this.baseURL}/reservation/`)
        .pipe(catchError(error => {
            this.errorMsg = error.message;
            return of([]);
        }));

    }

}