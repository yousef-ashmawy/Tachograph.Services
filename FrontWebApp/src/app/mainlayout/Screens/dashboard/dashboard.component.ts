import { Component } from '@angular/core';
import { AlertService } from 'src/app/_services/alert/alert.service';
import { TachographServicesStatsService } from 'src/app/_services/tachographservices/tachographservices-stats.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  Date:any;
  DriversData: any;
  constructor(private alertService: AlertService,
    private tachographservicesService: TachographServicesStatsService) {

  }
  ngOnInit() {
    this.loadDriversData();
  }

  loadDriversData() {
    this.tachographservicesService.getAllDriver().subscribe((data) => {
      this.DriversData = data
    },
    (err) => {
      this.alertService.error(err.error)
    })
  }

  Search(){
    console.log(this.Date);
    this.tachographservicesService.getAllDriverByFilter(this.Date).subscribe((data) => {
      this.DriversData = data
    },
    (err) => {
      this.alertService.error(err.error)
    })
  }
  
}
