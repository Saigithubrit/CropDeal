import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PaymentService } from '../_Services/payment.service';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {
  invoicelist:any;
  userid:any;
  @ViewChild('invoice') invoiceElement!: ElementRef;
  log=1;

  constructor( private service:PaymentService ) { 
    this.invoice();
  }

  ngOnInit(): void {
  }

invoice(){

  this.userid =localStorage.getItem('userid');
  this.service.invoice(this.userid).subscribe(result=>{
    if(result!=null){
       this.invoicelist=result;
  }}
  )


  
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



}
