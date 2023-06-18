import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-nav',
  templateUrl: './admin-nav.component.html',
  styleUrls: ['./admin-nav.component.css'],
})
export class AdminNavComponent implements OnInit {
  // ezay t8er sora
  url = './assets/download.jpg';
  x: any;
  user: any;

  constructor() {}

  onselectFile(e: any) {
    if (e.target.files) {
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0]);
      reader.onload = (event: any) => {
        this.url = event.target.result;
      };
    }
  }

  ngOnInit(): void {
    this.user =  localStorage.getItem('userDetail')
    this.user  = JSON.parse(this.user);
    
    console.log("getUser",this.user)
  }
}
