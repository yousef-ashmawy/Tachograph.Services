import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class Pager {
    curentPage: number = 1;
    pagesize: number = 10;
    refresh: Function = () => { };
    pageChange($event: any): void {
        this.curentPage = $event;
        this.refresh();
    }
    changeSize() {
        this.curentPage = 1;
        this.refresh();
    }
}