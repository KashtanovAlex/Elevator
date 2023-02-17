import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public url;
  public http;
  public messageServer = "";
  public messageText1 = "";
  public messageText2 = "";
  public messageText3 = "";


  constructor(httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = httpClient;
    this.url = baseUrl;
  }

  public sendMessage1() {
    var data = { User: 1, Content: this.messageText1 };

    var a = this.http.post(this.url + 'case2/message', data).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
    console.log(a);
  }

  public sendMessage2() {
    var data = { User: 2, Content: this.messageText2 };

    var a = this.http.post(this.url + 'case2/message', data).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
    console.log(a);
  }
  public sendMessage3() {

    var data = { User: 3, Content: this.messageText3 };

    var a = this.http.post(this.url + 'case2/message', data).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
    console.log(a);
  }

  public getMessage() {
    this.http.get<Message>(this.url + 'case2/message').subscribe(result => {
      this.messageServer = result.content;
    }, error => console.error(error));
  }
}
 class Message {
   public content = "";
   public id = 0;
}