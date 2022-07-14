import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { catchError } from 'rxjs/operators';
import { ApiClient } from "src/app.commons/apiClient.service";
import { HandleApiError } from "src/app.commons/handleApiError.service";
import { ServiceResult } from "src/app.commons/models/service-result.model";
import { Clientes } from "src/app/agendamento/model/Clientes";

@Injectable({
    providedIn: "root"
})

export class SchedullingService {
    errorMsg;
    constructor(private apiClient: ApiClient, private handleApiError: HandleApiError) {

    }

    setSchedule(filtro: Clientes): Observable<ServiceResult<any>> {

        return this.apiClient
            .post(`/Reservation`, filtro)
            .pipe(catchError(error => {
                this.errorMsg = error.message;
                return of([]);
            }));
    }
}