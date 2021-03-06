import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'The Dating app';
  users: any;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.getUsers();
  }

  private getUsers() {
    this.http.get('https://fibracsninvest.com.br/app/users').subscribe(Response => {
      this.users = Response;
      console.log(Response);
    }, error => {
      console.log(error);
    })
  }
}
