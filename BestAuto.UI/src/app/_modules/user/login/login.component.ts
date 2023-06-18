import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginDto } from 'src/app/_models/login-dto';
import { TokenDto } from 'src/app/_models/token';
import { AuthenticationService } from 'src/app/_services/authentication.service';
import { HomeService } from 'src/app/_services/home.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  user: LoginDto = {
    email: '',
    password: '',
  };

  constructor(public service: AuthenticationService, public router: Router, public homeService: HomeService) {}

  login() {
    this.service.login(this.user).subscribe((response: TokenDto) => {
      console.log(response);
      this.getUser();
      localStorage.setItem('token', response.token);
      this.homeService.sendMessage(response)
      //this.router.navigateByUrl('/home');

    });
  }

  getUser() {
    this.service.getUserDetail().subscribe((response: any) => {
      console.log("getUser response", response);
      localStorage.setItem('userDetail', JSON.stringify(response));
      let user: any =  localStorage.getItem('userDetail')
      this.router.navigateByUrl('/home');
      // this.homeService.sendMessage(response)

      console.log("getUser localStorage.setItem('token', response.token)", JSON.parse(user) );
    });
  }

  ngOnInit(): void {}
}
