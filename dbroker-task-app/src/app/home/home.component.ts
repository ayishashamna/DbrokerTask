import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone:true,
  imports: [FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  crNumber: string = '';

  constructor(private http: HttpClient, private router: Router) {}

  onSubmit() {
    var cr = new CrRequest()
    cr.CrNumber=this.crNumber
    this.http.post<any>('https://localhost:7192/api/cr', cr,{headers: { 'Content-Type': 'application/json' }})
      .subscribe(response => {
        //console.log(response)
        this.router.navigate(['/info'], { state: { data: response } });
      });
  }
}

class CrRequest{
  CrNumber:string = ''
}
