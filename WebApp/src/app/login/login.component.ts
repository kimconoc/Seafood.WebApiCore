import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userName: any;
  password: any;
  
  constructor(private service: SharedService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    var val = {
      userName: this.userName,
      password: this.password,
    };
    this.service.login(val).subscribe((response) => {
          // Lưu JWT vào localStorage
          localStorage.setItem('jwt', response.token);
          // Redirect hoặc thực hiện các hành động sau khi đăng nhập thành công
          this.router.navigate(['login/home']);
        }
      );
  }
}


