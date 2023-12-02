import { outputAst } from '@angular/compiler';
import { Component, OnInit, OnDestroy, Input, EventEmitter, Output } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { Subscription } from 'rxjs';
import { Alert, AlertType } from 'src/app/_models/alert';
import { AlertService } from 'src/app/_services/alert/alert.service';


@Component({ selector: 'alert', templateUrl: 'alert.component.html' })
export class AlertComponent implements OnInit, OnDestroy {
    @Input() id = 'default-alert';
    @Input() fade = true;
    @Output()
    messageEvent = new EventEmitter();
    confirmForm = false;
    alerts: Alert[] = [];
    alertSubscription!: Subscription;
    routeSubscription!: Subscription;


    constructor(private router: Router, private alertService: AlertService) { }

    ngOnInit() {
        // subscribe to new alert notifications
        this.alertSubscription = this.alertService.onAlert(this.id)
            .subscribe(alert => {
                if (!alert.message) {
                    // filter out alerts without 'keepAfterRouteChange' flag
                    this.alerts = this.alerts.filter(x => x.keepAfterRouteChange);

                    // remove 'keepAfterRouteChange' flag on the rest
                    this.alerts.forEach(x => delete x.keepAfterRouteChange);
                    return;
                }
                if (alert.type == AlertType.ConfirmDelete) {
                    this.confirmForm = true;
                } else {
                    this.confirmForm = false;
                }

                // add alert to array
                this.alerts.push(alert);

                // auto close alert if required
                if (alert.autoClose) {
                    setTimeout(() => this.removeAlert(alert), 3000);
                }
            });

        // clear alerts on location change
        this.routeSubscription = this.router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                this.alertService.clear(this.id);
            }
        });
    }

    ngOnDestroy() {
        // unsubscribe to avoid memory leaks
        this.alertSubscription.unsubscribe();
        this.routeSubscription.unsubscribe();
    }

    removeAlert(alert: Alert) {
        // check if already removed to prevent error on auto close
        if (!this.alerts.includes(alert)) return;

        if (this.fade) {
            // fade out alert
            alert.fade = true;

            // remove alert after faded out
            setTimeout(() => {
                this.alerts = this.alerts.filter(x => x !== alert);
            }, 250);
        } else {
            // remove alert
            this.alerts = this.alerts.filter(x => x !== alert);
        }
    }

    cssClass(alert: Alert) {
        if (!alert) return;

        const classes = ['alert', 'alert-dismissible', 'mt-4', 'container'];

        const alertTypeClass = {
            [AlertType.Success]: 'success',
            [AlertType.Error]: 'wrong',
            [AlertType.Info]: 'info',
            [AlertType.Warning]: 'warning',
            [AlertType.ConfirmDelete]: 'wrong',
        }


        if (alert.type !== undefined) {
            classes.push(alertTypeClass[alert.type]);
        }

        if (alert.fade) {
            classes.push('fade');
        }

        return classes.join(' ');
    }
    yesfunction() {
        this.messageEvent.emit(true);
    }
}


