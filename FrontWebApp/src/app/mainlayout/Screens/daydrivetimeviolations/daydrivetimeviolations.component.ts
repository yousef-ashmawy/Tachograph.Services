import { Component, OnInit } from '@angular/core';
import { AlertService } from 'src/app/_services/alert/alert.service';
import { TachographServicesStatsService } from 'src/app/_services/tachographservices/tachographservices-stats.service';


@Component({
  selector: 'app-daydrivetimeviolations',
  templateUrl: './daydrivetimeviolations.component.html',
  styleUrls: ['./daydrivetimeviolations.component.css']
})
export class DaydrivetimeviolationsComponent implements OnInit {
  Date:any;
  DriversData: any;
  constructor(private alertService: AlertService,
    private tachographservicesService: TachographServicesStatsService) {

  }
  ngOnInit() {
    this.loadDriversData();
  }

  loadDriversData() {
    this.tachographservicesService.getDaydrivetimeviolations().subscribe((data) => {
      this.DriversData = data
    },
      (err) => {
        this.alertService.error(err.error)
      })
  }

  Search(){
    console.log(this.Date);
    this.tachographservicesService.getDayDriveTimeViolationsByFilter(this.Date).subscribe((data) => {
      this.DriversData = data
    },
    (err) => {
      this.alertService.error(err.error)
    })
  }

}
