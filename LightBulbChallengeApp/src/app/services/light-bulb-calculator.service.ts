import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { LightBulbProblemResponse } from '../entities/lightbulbcalculatorentities'

@Injectable({
  providedIn: 'root'
})
export class LightBulbCalculatorService {

  myAppUrl: string;
  myApiUrl: string;
  public lightBulbProblemResponses: LightBulbProblemResponse[] = [];

  constructor(private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/calculation/';
  }

  solveLightProblem(numberOfPeople: number, numberOfLights: number): any {
    return this.http.get<LightBulbProblemResponse[]>(this.myAppUrl + this.myApiUrl + 'SolveLightBulbProblem/' + numberOfPeople + '/' +  numberOfLights)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
