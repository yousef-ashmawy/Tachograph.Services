import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tachographservicesApis } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TachographServicesStatsService {

  constructor(
    private http: HttpClient,

  ) { }
  public getAllDriver(): Observable<any> {
    let url = tachographservicesApis.getAll ;
    return this.http.get(url)
  }

  public getAllDriverByFilter(Date:any): Observable<any> {
    let url = tachographservicesApis.getAllDriverByFilter+'?Date='+Date ;
    return this.http.get(url)
  }

  public getDaydrivetimeviolations(): Observable<any> {
    let url = tachographservicesApis.getDayDriveTimeViolations ;
    return this.http.get(url)
  }

  public getDayDriveTimeViolationsByFilter(Date:any): Observable<any> {
    let url = tachographservicesApis.getDayDriveTimeViolationsByFilter+'?Date='+Date ;
    return this.http.get(url)
  }

  public getRestTimeViolations(): Observable<any> {
    let url = tachographservicesApis.getRestTimeViolations ;
    return this.http.get(url)
  }

  public getRestTimeViolationsByFilter(Date:any): Observable<any> {
    let url = tachographservicesApis.getRestTimeViolationsByFilter+'?Date='+Date ;
    return this.http.get(url)
  }

  public getSingleDriveTimeViolations(): Observable<any> {
    let url = tachographservicesApis.getSingleDriveTimeViolations ;
    return this.http.get(url)
  }

  public getSingleDriveTimeViolationsByFilter(Date:any): Observable<any> {
    let url = tachographservicesApis.getSingleDriveTimeViolationsByFilter+'?Date='+Date ;
    return this.http.get(url)
  }

  public getWeekDriveTimeViolations(): Observable<any> {
    let url = tachographservicesApis.getWeekDriveTimeViolations ;
    return this.http.get(url)
  }

}
