import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'front-end';

  route = "";
  routeGeneroAdd = "/genero/add";
  routeActorAdd = "/actor/add";


  constructor(private router: Router){}


  ngOnInit(): void {
    this.router.events.subscribe(() => {
      this.route = this.router.url;
    });
  }

}
