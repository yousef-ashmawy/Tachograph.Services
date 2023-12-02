import { Component, OnInit } from '@angular/core';
import { AlertService } from 'src/app/_services/alert/alert.service';
import { TachographServicesStatsService } from 'src/app/_services/tachographservices/tachographservices-stats.service';


@Component({
  selector: 'app-weekdrivetimeviolations',
  templateUrl: './weekdrivetimeviolations.component.html',
  styleUrls: ['./weekdrivetimeviolations.component.css']
})
export class WeekdrivetimeviolationsComponent implements OnInit {
  Date:any;
  DriversData: any;
  constructor(private alertService: AlertService,
    private tachographservicesService: TachographServicesStatsService) { }

  ngOnInit() {
    this.loadDriversData();
  }

  loadDriversData() {
    this.tachographservicesService.getWeekDriveTimeViolations().subscribe((data) => {
      this.DriversData = data
    },
      (err) => {
        this.alertService.error(err.error)
      })
  }

}
