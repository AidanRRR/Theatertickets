import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  public zaalplan;
  public rijen;

  constructor() {
    this.bouwZaalpanMlc();
  }

  bouwZaalpanMlc() {
    var rijen = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R"]

    let zaalplan = new Array();
    for (let i = 0; i < 18; i++) {
      let stoel;
      for (let j = 1; j <= 36; j++) {
        stoel = {
          "id": rijen[i] + j,
          "tekst": j,
          "isBeschikbaar": true,
          "isUitgeschakeld": false
        }
        stoel.rij = rijen[i];
        zaalplan.push(stoel);
      }
    }

    this.zaalplan = zaalplan;
    this.rijen = rijen;
    //console.log(this.zaalplan);
  }
}
