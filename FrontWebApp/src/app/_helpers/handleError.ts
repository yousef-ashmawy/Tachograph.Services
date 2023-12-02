import { Injectable } from "@angular/core";
import { AlertService } from "../_services/alert/alert.service";

@Injectable({ providedIn: 'root' })
export class HandleError {
  constructor(public alertService: AlertService) {
  }
  
  showErrors(err: any) {
    
    const errorsObj = err.error.errors;
    let errorMessage = "";
    
    if(errorsObj){
      for (const key in errorsObj) {
        const errorMessages = errorsObj[key];
        for (let i = 0; i < errorMessages.length; i++) {
          errorMessage += errorMessages[i] + '<br />'
        }
      }
    }
    else{
      errorMessage = err.error.Message;
    }

    this.alertService.error(errorMessage)
  }

  showDirectErrors(err: any) {
    this.alertService.error(err.error.Message)
  }

  showErrorMessage(errorMsg : string){
    this.alertService.error(errorMsg);
  }
}