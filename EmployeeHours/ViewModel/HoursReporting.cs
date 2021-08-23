using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EmployeeHours.ViewModel
{
    public static class HoursReporting
    {
        public static void PrintDocument(EmployeeHours.Model.Employee _selectedEmployee)
        {
            //Set Up document + Show print dialog
            PrintDialog printDlg = new PrintDialog();
            FlowDocument reportDocument = Print(_selectedEmployee);
            reportDocument.Name = "EmployeeHours";
            IDocumentPaginatorSource idpSource = reportDocument;
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Employee Hours");
        }

        private static FlowDocument Print(EmployeeHours.Model.Employee _selectedEmployee)
        {
            //Create Report 
            FlowDocument reportDocument = new FlowDocument();            
            Section sectionMain = new Section();             
            Paragraph nameParagraph = new Paragraph();

            FormatHeader(nameParagraph, _selectedEmployee.Name);
            AddParagraphToSection(reportDocument, sectionMain, nameParagraph);

            Paragraph hoursWorkedParagraph = new Paragraph();
            hoursWorkedParagraph.Inlines.Add("Hours Worked : " + _selectedEmployee.EmployeeHours.FirstOrDefault().Hours );
            AddParagraphToSection(reportDocument, sectionMain, hoursWorkedParagraph);

            Paragraph breakParagraph = new Paragraph();           
            breakParagraph.Inlines.Add("Mandatory Break Time Accumulated : " + _selectedEmployee.EmployeeHours.FirstOrDefault().BreakTime);
            AddParagraphToSection(reportDocument, sectionMain, breakParagraph);

            return reportDocument;

        }

        //Add A new paragrph to desired section in document 
        private static void AddParagraphToSection(FlowDocument documentToAddTo,Section sectionToAddTo,Paragraph paragraphToAdd)
        {
            sectionToAddTo.Blocks.Add(paragraphToAdd);
            documentToAddTo.Blocks.Add(sectionToAddTo);
        }

        //Format Header of Report
        private static void FormatHeader(Paragraph nameParagraph , string employeeName )
        {
            Bold bld = new Bold();
            bld.Inlines.Add(new Run(employeeName + ""));
            Italic italicBld = new Italic();
            italicBld.Inlines.Add(bld);
            Underline underlineItalicBld = new Underline();
            underlineItalicBld.Inlines.Add(italicBld);
            nameParagraph.Inlines.Add(underlineItalicBld);
        }

    }
}
