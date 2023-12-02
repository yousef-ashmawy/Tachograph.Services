import { Component, OnInit } from '@angular/core';
import { LoaderService } from 'src/app/_services/loader/loader.service';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css']
})
export class SpinnerComponent implements OnInit {

  constructor(public loader: LoaderService) { }

  ngOnInit() {
  }

}
