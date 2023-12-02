import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.css']
})
export class PagerComponent {
  @Input() PageCounter: number = 3
  @Input() CurentPage: number = 1
  @Output()
  messageEvent = new EventEmitter();
  numbers
  constructor(public translate: TranslateService) {
    this.numbers = Array(this.PageCounter).fill(1).map((x, i) => i + 1);
  }
  ngOnChanges(changes: SimpleChanges): void {
    this.numbers = Array(this.PageCounter).fill(1).map((x, i) => i + 1);
  }
  changePage(Next: boolean = true) {
    if (Next) {
      this.CurentPage++
    } else {
      this.CurentPage--
    }
    this.messageEvent.emit(this.CurentPage);

  }
  setNumber(NewCurrentPage: number) {
    this.CurentPage = NewCurrentPage;
    this.messageEvent.emit(this.CurentPage);

  }
}
