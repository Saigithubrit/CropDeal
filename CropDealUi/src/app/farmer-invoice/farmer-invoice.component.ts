import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PaymentService } from '../_Services/payment.service';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-farmer-invoice',
  templateUrl: './farmer-invoice.component.html',
  styleUrls: ['./farmer-invoice.component.css']
})
export class FarmerInvoiceComponent implements OnInit {

  constructor(private service:PaymentService) { }
  userid:any;
  invoicelist:any;
  @ViewChild('invoice') invoiceElement!: ElementRef;
  ngOnInit(): void {
    this.invoice();
  }
 
  invoice(){
    this.userid =localStorage.getItem('userid');
    this.service.Farmerinvoice(this.userid).subscribe(result=>{
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
      PDF.save('invoice-Cropdeal.pdf');
    });
  }

}
