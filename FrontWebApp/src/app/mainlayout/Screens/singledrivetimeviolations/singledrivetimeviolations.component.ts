import { Component, OnInit } from '@angular/core';
import { AlertService } from 'src/app/_services/alert/alert.service';
import { TachographServicesStatsService } from 'src/app/_services/tachographservices/tachographservices-stats.service';

@Component({
  selector: 'app-singledrivetimeviolations',
  templateUrl: './singledrivetimeviolations.component.html',
  styleUrls: ['./singledrivetimeviolations.component.css']
})
export class SingledrivetimeviolationsComponent implements OnInit {
  Date:any;
  DriversData: any;
  constructor(private alertService: AlertService,
    private tachographservicesService: TachographServicesStatsService) { }

  ngOnInit() {
    this.loadDriversData();
  }

  loadDriversData() {
    this.tachographservicesService.getSingleDriveTimeViolations().subscribe((data) => {
      this.DriversData = data
    },
      (err) => {
        this.alertService.error(err.error)
      })
  }

  Search(){
    console.log(this.Date);
    this.tachographservicesService.getSingleDriveTimeViolationsByFilter(this.Date).subscribe((data) => {
      this.DriversData = data
    },
    (err) => {
      this.alertService.error(err.error)
    })
  }

}
