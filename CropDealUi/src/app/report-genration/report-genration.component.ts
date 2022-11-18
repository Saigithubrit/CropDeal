import { Component, OnInit,ViewChild, ElementRef  } from '@angular/core';
import { PaymentService } from '../_Services/payment.service';
import { RegisterService } from '../_Services/register.service';
import {ModalDismissReasons, NgbModal} from '@ng-bootstrap/ng-bootstrap'; 
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
import { Router } from '@angular/router';



@Component({
  selector: 'app-report-genration',
  templateUrl: './report-genration.component.html',
  styleUrls: ['./report-genration.component.css']
})
export class ReportGenrationComponent implements OnInit {

  constructor(private service:RegisterService,private ser:PaymentService,private modalService: NgbModal,private route:Router) { }
  profile:any;
  invoices:any;
  closeResult: string = '';
  log=1;
  
  @ViewChild('invoice') invoiceElement!: ElementRef;

  ngOnInit(): void {
    this.getProfies();
  }
  
  public generatePDF(): void {
        
    html2canvas(this.invoiceElement.nativeElement, { scale: 3 }).then((canvas) => {
      const imageGeneratedFromTemplate = canvas.toDataURL('image/png');
      const fileWidth = 200;
      const generatedImageHeight = (canvas.height * fileWidth) / canvas.width;
      let PDF = new jsPDF('p', 'mm', 'a4',);
      PDF.addImage(imageGeneratedFromTemplate, 'PNG', 0, 5, fileWidth, generatedImageHeight,);
      PDF.html(this.invoiceElement.nativeElement.innerHTML)
      PDF.save('Invoice-cropdeal.pdf');
    });
  }
   
  getProfies(){
    this.service.GetUsers().subscribe(result =>{
      if(result!=null){
      this.profile=result;
    }else{
      alert("No users found");
    }
    },(err)=>{
     
      if(err.status==403){
        this.route.navigate(['/Unauthorized'])
       
      }else{
  
        alert("Some error occured! come back later");
      }
    }
    );

  }

  GetInvoices(userid:any){
    this.log=2;
  this.ser.Farmerinvoice(userid).subscribe(result=>{
    if(result!=null){
    this.invoices=result
    }else{
      alert("No invoices found");
    }
  })

  }

  GetInvoicesDealer(userid:any){
    this.log=2;
    this.ser.invoice(userid).subscribe(result=>{
      if(result!=null){
      this.invoices=result
      }else{
        alert("No invoices found");
      }
    })

  }

  
 
  

}
