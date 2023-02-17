import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { interval, Subscription } from 'rxjs';
import { timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public currentCount = 0;
  public floorCount = 1;
  public currentFloor = 1;
  public url;
  public http;
  public elevatorPosition = 1;


  public buttonOutSideTexts: Array < string > =['1'];
  public buttonInSideTexts: Array<string> = ['1'];


  public checkedFloorCount(): void {
    while (+this.buttonOutSideTexts[this.buttonOutSideTexts.length - 1] != this.floorCount) {
      if (+this.buttonOutSideTexts[this.buttonOutSideTexts.length - 1] <= this.floorCount - 1) {
        this.buttonOutSideTexts = [...this.buttonOutSideTexts, `${+this.buttonOutSideTexts[this.buttonOutSideTexts.length - 1] + 1}`];
        this.buttonInSideTexts = [...this.buttonInSideTexts, `${+this.buttonInSideTexts[this.buttonInSideTexts.length - 1] + 1}`];
      }
      else {
        this.buttonOutSideTexts.pop();
        this.buttonInSideTexts.pop();
      }
    }

    var data = { floorCount: this.floorCount };
    var a = this.http.post(this.url + 'elevatorinfo', data).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
    console.log(a);
  }

  constructor(httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = httpClient;
    this.url = baseUrl;
    this.getElevatorPosition();
  }

  public selectOutSideFloor(index: number, b: object): void {
    var data = { currentFloor: index + 1 };
    var a = this.http.post(this.url + 'outsidebutton', data).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }
  public selectInSideFloor(index: number, b: object): void {
    console.log(index);
    var data = { currentFloor: index + 1 };
    var a = this.http.post(this.url + 'insidebutton', data).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }
  

  public getElevatorPosition() {
    interval(1000) 
      .pipe(switchMap(() => this.http.get<number>(this.url + 'elevatorinfo'))).subscribe(result => {
      this.elevatorPosition = result;
    }, error => console.error(error));
  }
}

