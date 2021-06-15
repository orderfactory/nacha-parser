﻿SET NOCOUNT ON

MERGE INTO [dbo].[AchReasonCode] AS [Target]
USING (VALUES
  (N'C01',N'Incorrect DFI Account Number',N'Account number is incorrect or is formatted incorrectly. Correct DFI Account Number appears in the first (left justification) 17 positions of the Corrected Data Field.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C02',N'Incorrect Routing Number',N'Due to a merger or consolidation, a once valid routing number must be changed. Correct Routing Number (including check digit) appears in first 9 positions of the Corrected Data Field.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C03',N'Incorrect Routing Number and Incorrect DFI Account Number',N'Due to a merger or consolidation, a once valid routing number must be changed, and this change will cause a change to the account number structure. Correct routing number should be entered in Change Field 1 and correct account number should be entered in Change Field 2. (Note: This code is not available for use with IAT.)','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C04',N'Incorrect Individual Name/Receiving Company Name',N'Customer has changed name or ODFI has submitted the name incorrectly. NOCs may not be submitted for name changes on Federal Government items. (Note: Effective March 20, 2015, this change code will no longer be available.)','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C05',N'Incorrect Transaction Code',N'An item which the RDFI determines should be posted to a different account type. The correct Transaction Code should be placed in Change Field 1.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C06',N'Incorrect DFI Account Number and Incorrect Transaction Code',N'Correct account number appears in the first (left justification) 17 positions of the Addenda Information Field; correct Transaction Code appears in positions 21 and 22 of the same field with spaces in positions 18 through 20. (Note: This code is not available for use with IAT.)','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C07',N'Incorrect Routing Number, Incorrect DFI Account Number and Incorrect Transaction Code',N'Correct routing number appears in the first 9 positions of the Addenda Information Field; correct account number appears in positions 10 through 26 of the same field and correct Transaction Code appears in positions 27 and 28 of the same field. (Note: This code is not available for use with IAT.)','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C08',N'Incorrect Foreign Receiving DFI Identification (IAT Only)',N'The correct Foreign Receiving DFI identification appears in the first (left justification) 11 positions of the Corrected Data Field.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C09',N'Incorrect Individual ID Number/Incorrect Receiver Identification Number',N'Individual''s ID number is incorrect. This correction applies to transactions initiated by the customer, which may require a PIN number for identification.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C13',N'Addenda Format Error',N'Information in the Entry Detail Record was correct and the entry was able to be posted by the RDFI, but information in the addenda record was unclear or formatted incorrectly. For example, a CCD entry addenda record does not contain ANSI X12.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C14',N'Incorrect SEC Code for Outbound International Payment',N'The Gateway has identified the entry as an outbound international payment and is requesting future entries be identified as IAT. (Note: This code is to be used by the Gateway only.)','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C61',N'Misrouted Notification of Change',N'NOC was sent to wrong ODFI due to error in routing number.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C62',N'Incorrect Trace Number',N'Trace number could not be identified.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C63',N'Incorrect Company Identification Number',N'Company Identification Number could not be identified. The ODFI cannot identify the originating company.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C64',N'Incorrect Individual Identification Number',N'Individual Identification Number could not be identified. Identification number can be identified, but individual can''t be identified because of incorrect identification number.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C65',N'Incorrectly Formatted Corrected Data',N'Information in addenda record of the NOC could not be processed.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C66',N'Incorrect Discretionary Data',N'Discretionary data was not included or contained errors.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C67',N'Routing Number Not from Original Entry Detail Record',N'Routing number did not match data in original entry.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C68',N'DFI Account Number Not from Original Entry Detail Record',N'DFI Account Number did not match data in original entry.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'C69',N'Incorrect Transaction Code',N'Transaction Code does not match with the Transaction Code of the original entry.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R01',N'Insufficient Funds',N'Available balance is not sufficient to cover the dollar value of the debit entry.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R02',N'Account Closed',N'Previously active account has been closed by customer or RDFI.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R03',N'No Account/Unable to Locate Account',N'Account number structure is valid and passes editing process, but does not correspond to individual identified in entry or is not an open account. (Note: This Return Reason Code may not be used to return ARC, BOC or POP entries solely because they do not contain an Individual Name.)','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R04',N'Invalid Account Number',N'Account number structure not valid; entry failed check digit validation or may contain an incorrect number of digits.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R05',N'Unauthorized Debit to Consumer Account Using Corporate SEC Code (Extended Return Entry)',N'A CCD or CTX debit entry was transmitted to a Consumer Account of the Receiver and was not authorized by the Receiver. Written Statement required.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R06',N'Returned per ODFI''s Request',N'ODFI has requested RDFI to return the ACH entry (optional to RDFI); ODFI indemnifies RDFI.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R07',N'Authorization Revoked by Customer (Extended Return Entry)',N'Consumer, who previously authorized ACH payment, has revoked authorization from Originator. Must be returned no later than 60 days from Settlement Date and the RDFI must obtain a Written Statement. Prohibited use for ARC, BOC, POP and RCK.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R08',N'Payment Stopped',N'Receiver of a debit transaction has stopped payment on a specific ACH debit. (For consumer accounts, RDFI should verify whether the Receiver''s intent is to stop one payment or all future payments.)','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R09',N'Uncollected Funds',N'Sufficient book or ledger balance exists to satisfy dollar value of the transaction, but the dollar value of transactions in process of collection (i.e., uncollected checks) brings available or cash reserve balance below dollar value of the debit entry.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R10',N'Customer Advises Originator is Not Known to Receiver and/or Originator is Not Authorized by Receiver to Debit Receiver’s Account',N'Receiver does not know the identity of the Originator, or has no relationship with the Originator, or has not authorized the Originator to debit the account, or (for ARC and BOC entries) the signature on the source document is not authentic, valid, or authorized, or (for POP entries) the signature on the written authorization is not authentic, valid, or authorized.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R11',N'Customer Advises Entry Not in Accordance with the Terms of the Authorization',N'The Originator and Receiver have a relationship, and an authorization to debit exists, but there is an error or defect in the payment such that the entry does not conform to the terms of the authorization.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R12',N'Account Sold to Another DFI',N'Financial institution may continue to receive entries destined for an account that has been sold to another financial institution.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R13',N'Invalid ACH Routing Number',N'Entry contains a Receiving DFI Identification or Gateway Identification that is not a valid ACH routing number.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R14',N'Representative Payee Deceased or Unable to Continue in that Capacity',N'The representative payee authorized to accept entries on behalf of a beneficiary is either deceased or unable to continue in that capacity.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R15',N'Beneficiary or Account Holder (Other than Representative Payee) Deceased',N'(1) The beneficiary entitled to payments is deceased; or (2) the account holder other than a representative payee is deceased.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R16',N'Account Frozen',N'Access to account is restricted due to specific action taken by the RDFI or by legal action; or OFAC has instructed the RDFI to return the entry.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R17',N'File Record Edit Criteria',N'Fields not edited by the ACH Operator are edited by the RDFI and cannot be processed; field(s) causing processing error must be identified in the addenda record of return.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R18',N'Improper Effective Entry Date',N'Effective date of the ACH entry is outside of the processing window of either a credit or debit entry (beyond two days for a credit entry or beyond one day for a debit entry).','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R19',N'Amount Field Error',N'The amount field is: (1) non-numeric, (2) not zero in a Prenotification, DNE, ENR or NOC (3) a zero amount in an ACH "valued" transaction format or (4) the amount is greater than $25,000 for ARC, BOC and POP entries.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R20',N'Non-Transaction Account',N'ACH entry is destined for a non-transaction account (i.e., an account against which transactions are prohibited or limited).','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R21',N'Invalid Company Identification',N'Identification number used in the Company ID field is not valid. This return reason code is normally used for CIE entries.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R22',N'Invalid Individual ID Number',N'In a CIE or MTE entry, the Individual ID Number is used by the Receiver to identify the account; Receiver has indicated to RDFI that the number identified by the Originator is not correct.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R23',N'Credit Refused by Receiver',N'Receiver refuses credit entry because of one of the following conditions: (1) minimum amount required by Receiver has not been remitted, (2) exact amount required has not been remitted, (3) account subject to litigation and Receiver will not accept transaction, (4) acceptance of transaction results in overpayment, (5) Originator is not known by Receiver or (6) Receiver has not authorized the credit entry. ','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R24',N'Duplicate Entry',N'RDFI has received what appears to be a duplicate entry (i.e., trace number, date, dollar amount and/or other data matches another transaction). This code should be used with extreme care as the Originator may have originated a reversal transaction to handle the situation.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R25',N'Addenda Error',N'An error exists in the addenda record in regards to application of codes, values, content or required formatting standards.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R26',N'Mandatory Field Error',N'An error exists in a field which is required for ACH processing and is subject to edits by the ACH Operator.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R27',N'Trace Number Error',N'Original Entry Trace Number is either not present in the addenda record of an automated return or Notification of Change entry or disagrees with the preceding Entry Detail Record.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R28',N'Routing Number Check Digit Error',N'The check digit for a routing number is invalid.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R29',N'Corporate Customer Advises Not Authorized',N'RDFI has been notified by Receiver (non-consumer) that entry was not authorized.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R30',N'RDFI Not Participant In Check Truncation Program',N'Non-participating RDFI or routing number is incorrect.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R31',N'Permissible Return Entry (CCD and CTX Only)',N'RDFI has been notified by ODFI that ODFI agrees to accept a return entry beyond normal return deadline.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R32',N'RDFI Non-Settlement',N'RDFI is not able to settle the entry.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R33',N'Return of XCK Entry',N'RDFI, at its discretion, returns an XCK entry (code only used for XCK returns). XCK entries may be returned up to 60 days after Settlement Date.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R34',N'Limited Participation DFI',N'The RDFI''s participation has been limited by a federal or state supervisor.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R35',N'Return of Improper Debit Entry',N'ACH debit not permitted for use with the CIE Standard Entry Class Code or ACH debit not permitted to loan accounts (except for reversals).','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R36',N'Return of Improper Credit Entry',N'ACH credit not permitted for use with ARC, BOC, POP, RCK, TEL, WEB or XCK which are limited to debits to demand accounts (except for reversals).','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R37',N'Source Document Presented for Payment (Adjustment Entry)',N'The source document to which an ARC, BOC or POP entry relates has been presented for payment. RDFI must obtain a Written Statement and return the entry within 60 days following Settlement Date.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R38',N'Stop Payment on Source Document (Adjustment Entry)',N'A stop payment has been placed on the source document to which the ARC or BOC entry relates. RDFI must return no later than 60 days following Settlement Date. No Written Statement is required as the original stop payment form covers the return.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R39',N'Improper Source Document',N'The RDFI has determined the source document used for the ARC, BOC or POP entry to its Receiver''s account is improper.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R50',N'State Law Affecting RCK Acceptance',N'RDFI is located in a state that has not adopted Revised Article 4 of the UCC or the RDFI is located in a state that requires all canceled checks to be returned within the periodic statement.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R51',N'Item Related to RCK Entry is Ineligible or RCK Entry is Improper',N'The item to which the RCK entry relates was not eligible, Originator did not provide notice of the RCK policy, signature on the item was not genuine, the item has been altered or amount of the entry was not accurately obtained from the item. RDFI must obtain a Written Statement and return the entry within 60 days following Settlement Date.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R52',N'Stop Payment on Item (Adjustment Entry)',N'A stop payment has been placed on the item to which the RCK entry relates. RDFI must return no later than 60 days following Settlement Date. No Written Statement is required as the original stop payment form covers the return.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R53',N'Item and RCK Entry Presented for Payment (Adjustment Entry)',N'Both the RCK entry and check have been presented for payment. RDFI must obtain a Written Statement and return the entry within 60 days following Settlement Date.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R61',N'Misrouted Return',N'RDFI of the original entry has placed the incorrect routing number in the Receiving DFI Identification field.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R62',N'Return of Erroneous or Reversing Debit',N'Usage is limited to reversal scenarios in which the Receiver is unintentionally credited.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R67',N'Duplicate Return',N'ODFI has received more than one return for the same entry.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R68',N'Untimely Return',N'Return was not sent within the time frame established by the ACH Rules.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R69',N'Field Error(s)',N'One or more of the field requirements are incorrect.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R70',N'Permissible Return Entry Not Accepted/Return Not Requested By ODFI',N'ODFI has received a return identified as being returned with the permission of the ODFI (Return Reason Code R31), but the ODFI has not agreed to accept the entry or ODFI has received a return entry (Return Reason Code R06) which they did not request. ','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R71',N'Misrouted Dishonored Return',N'ODFI has placed the incorrect routing number in the RDFI Identification field.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R72',N'Untimely Dishonored Return',N'Dishonored return was not sent within five banking days of the Settlement Date of the return entry.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R73',N'Timely Original Return',N'RDFI certifies that the original return was sent within the time frame designated in the ACH Rules. This code may be used by the RDFI to contest an entry dishonored by the ODFI using Return Reason Code R68 (Untimely Returns).','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R74',N'Corrected Return',N'RDFI is correcting a previous return that was dishonored because it contained incomplete or incorrect information. This code may be used by the RDFI to contest an entry dishonored by the ODFI using Return Reason Code R69 (Field Error(s)).','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R75',N'Original Return Not a Duplicate',N'The original return entry was not a duplicate of an entry previously returned by the RDFI. This code may be used by the RDFI to contest an entry dishonored by the ODFI using Return Reason Code R67 (Duplicate Return).','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R76',N'No Errors Found',N'The original return entry did not contain the errors indicated by the ODFI in the Dishonored Return Entry bearing Return Reason Code R69 (Field Error(s)).','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R77',N'Non-Acceptance of R62 Dishonored Return',N'RDFI returned both the erroneous entry and related reversing entry; or the funds related to the R62 are not recoverable from the Receiver.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R80',N'IAT Entry Coding Error',N'The IAT entry is being returned due to one or more of the following conditions: invalid DFI/Bank Branch Country Code, invalid DFI/Bank Identification Number Qualifier, invalid Foreign Exchange Indicator, invalid ISO Originating Currency Code, invalid ISO Destination Currency Code, invalid ISO Destination Country Code or invalid Transaction Type Code.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R81',N'Non-Participant in IAT Program',N'The Gateway does not have an agreement with the ODFI to process IAT entries.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R82',N'Invalid Foreign Receiving DFI Identification',N'The reference used to identify the foreign receiving DFI is invalid.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R83',N'Foreign Receiving DFI Unable to Settle',N'The IAT entry is being returned due to settlement problems in the foreign payment system.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R84',N'Entry Not Processed by Gateway',N'The outbound IAT entry has not been processed and is being returned at the Gateway''s discretion because either (1) the processing may expose the Gateway to excessive risk or (2) the foreign payment system does not support the functions needed to process the transaction.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
 ,(N'R85',N'Incorrectly Coded Outbound International Payment',N'The Gateway has identified the entry as an outbound international payment and is returning the entry because it does not bear the IAT SEC code.','2021-06-14T21:13:25.0600000','2021-06-14T21:13:25.0600000',N'AzureAD\SergeyNosov',N'AzureAD\SergeyNosov')
) AS [Source] ([Id],[Title],[Description],[DateCreated],[DateUpdated],[CreatedBy],[UpdatedBy])
ON ([Target].[Id] = [Source].[Id])
WHEN MATCHED AND (
	NULLIF([Source].[Title], [Target].[Title]) IS NOT NULL OR NULLIF([Target].[Title], [Source].[Title]) IS NOT NULL OR 
	NULLIF([Source].[Description], [Target].[Description]) IS NOT NULL OR NULLIF([Target].[Description], [Source].[Description]) IS NOT NULL OR 
	NULLIF([Source].[DateCreated], [Target].[DateCreated]) IS NOT NULL OR NULLIF([Target].[DateCreated], [Source].[DateCreated]) IS NOT NULL OR 
	NULLIF([Source].[DateUpdated], [Target].[DateUpdated]) IS NOT NULL OR NULLIF([Target].[DateUpdated], [Source].[DateUpdated]) IS NOT NULL OR 
	NULLIF([Source].[CreatedBy], [Target].[CreatedBy]) IS NOT NULL OR NULLIF([Target].[CreatedBy], [Source].[CreatedBy]) IS NOT NULL OR 
	NULLIF([Source].[UpdatedBy], [Target].[UpdatedBy]) IS NOT NULL OR NULLIF([Target].[UpdatedBy], [Source].[UpdatedBy]) IS NOT NULL) THEN
 UPDATE SET
  [Target].[Title] = [Source].[Title], 
  [Target].[Description] = [Source].[Description], 
  [Target].[DateCreated] = [Source].[DateCreated], 
  [Target].[DateUpdated] = [Source].[DateUpdated], 
  [Target].[CreatedBy] = [Source].[CreatedBy], 
  [Target].[UpdatedBy] = [Source].[UpdatedBy]
WHEN NOT MATCHED BY TARGET THEN
 INSERT([Id],[Title],[Description],[DateCreated],[DateUpdated],[CreatedBy],[UpdatedBy])
 VALUES([Source].[Id],[Source].[Title],[Source].[Description],[Source].[DateCreated],[Source].[DateUpdated],[Source].[CreatedBy],[Source].[UpdatedBy])
WHEN NOT MATCHED BY SOURCE THEN 
 DELETE;

DECLARE @mergeError int
 , @mergeCount int
SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
IF @mergeError != 0
 BEGIN
 PRINT 'ERROR OCCURRED IN MERGE FOR [dbo].[AchReasonCode]. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100)); -- SQL should always return zero rows affected
 END
ELSE
 BEGIN
 PRINT '[dbo].[AchReasonCode] rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
 END
GO


SET NOCOUNT OFF
GO