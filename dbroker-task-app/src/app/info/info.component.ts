import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-info',
  standalone:true,
  imports: [CommonModule],
  templateUrl: './info.component.html',
  styleUrl: './info.component.css'
})
export class InfoComponent {
 
  data:any;

  constructor(private router: Router,private http: HttpClient) {
    this.data = this.router.getCurrentNavigation()?.extras.state?.['data'];
    //console.log(this.data)
  }
  
  async onNext() {
    try {
      const response = await this.http.post<any>('https://localhost:7192/api/cr/save', this.data);
      alert("Data saved successfully")
      this.router.navigate(['/home']);
    } catch (error) {
      console.error('Error saving data:', error);
    }
  }
}
