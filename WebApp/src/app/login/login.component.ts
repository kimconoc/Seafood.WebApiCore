import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  name: any;
  password: any;
  
  constructor(private service: SharedService) { }

  ngOnInit() {
  }

  login(user : any) {
    this.service.login(user).subscribe((token : string) => {
      localStorage.setItem('authToken', token);
    })
  }

}
