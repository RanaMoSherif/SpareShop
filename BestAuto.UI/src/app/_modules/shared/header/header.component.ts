import { Component, OnInit } from '@angular/core';
import { HomeService } from 'src/app/_services/home.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  user: any;

  constructor(public homeService: HomeService) { }

  ngOnInit(): void {

    this.homeService.getMessage().subscribe(res => {
      console.log("getMessage",  res );

      if ( res) {
      console.log("getMessage",  res );
      this.user =  res;
      console.log("getMessage",  this.user );
    }
    })


    if (!this.user?.role) {
      this.user =  localStorage.getItem('userDetail')
      this.user  = JSON.parse(this.user);
      
    }


  }


  logout() {
    this.homeService.clearMessages();
    this.user = undefined;
    localStorage.removeItem("userDetail")
  }


}
