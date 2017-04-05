Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class NopTests2

    <TestMethod()> Public Sub TestMethod1()
    End Sub

End Class

Public Class TrilboneXML

    Public Shared ReadOnly Property HTML_EN As XElement
        Get
            Dim _xml As XElement = <html>
                                       <head>
                                           <META http-equiv="Content-Type" content="text/html; charset=windows-1251"/>
                                           <title>Kimberella quadrata (Glaessner,Wade,1966)</title>
                                           <style type="text/css">
                  /* CSS Document */
                  /*body*/
                  .body_color {
                  background-color:#cebf96;
                  }
				.main_block {
				background-color:#d3cfb1;
				border-style: ridge;
				border-color: rgb(78,63,33);
				}
                  /*caption*/
                  .caption_sample {
                  font-family: "Bodoni MT";
                  font-size: x-large;
                  font-style: normal;
                  line-height: normal;
                  font-weight: bold;
                  color: rgb(78,63,33);
                  text-align:center;
                  vertical-align:top;
                  }

                  /*found in*/
                  .locality {
                  font-family: "Bodoni MT";
                  font-size: large;
                  font-style: normal;
                  line-height: normal;
                  font-weight: normal;
                  color: rgb(78,63,33);
                  }

                  /*age field*/
                  .age {
                  font-family: "Bodoni MT";
                  font-size: large;
                  font-style: normal;
                  line-height: normal;
                  font-weight: normal;
                  color: rgb(78,63,33);
                  background-color: #c7acbd;
                  text-align:center;
                  }

                  /*vid description*/
                  .described {
                  font-family: "Bodoni MT";
                  font-size: large;
                  font-style:normal;
                  line-height: normal;
                  font-weight: normal;
                  color: rgb(78,63,33);
                  text-align:left;
                  }

                  /*size*/
                  .size {
                  font-family: "Bodoni MT";
                  font-size: large;
                  font-style: normal;
                  line-height: normal;
                  font-weight: normal;
                  color: rgb(78,63,33);
                  }

                  /*remarks*/
                  .remarks {
                  font-family: "Bodoni MT";
                  font-size: large;
                  font-style: normal;
                  line-height: normal;
                  font-weight: normal;
                  color: rgb(78,63,33);
                  }

                  /*addtext*/
                  .addtext {
                  font-family: "Bodoni MT";
                  font-size: large;
                  font-style: normal;
                  line-height: normal;
                  font-weight: normal;
                  color: rgb(78,63,33);
                  }

                  /*barcode*/
                  .bartext {
                  font-family: "Bodoni MT";
                  font-size: 10pt;
                  font-style: normal;
                  line-height: normal;
                  font-weight: lighter;
                  color: rgb(78,63,33);
                  }

                  /*Arrow*/
                  .arrow
                  {
                  width: 20px;
                  height: 20px;
                  
         
                  }
                  
                  /*body_color*/
                  .body_color {
                  background-color:#cebf96;
                  font-family: "Bodoni MT";
                  line-height: normal;
                  font-size:small;
                  color: rgb(78,63,33);
                  }



                  .hr_sample{
                  height: 5px;
                  background-color: rgb(78,63,33);
                  }



                  .hr_catalog{
                  height: 7px;
                  background-color: rgb(78,63,33);
                  }



                  .caption_catalog {
                  background-color: #C0C0C0;
                  font-size: x-large;
                  font-weight: bold;
                  text-align:center;
                  vertical-align:top;
                  }



                  .div_main
                  {
                  display:block;
                  left: 5%;
                  top: 0px;
                  height: 100%;
                  }


                  .NUMBER
                  {
                  font-size: x-small;
                  font-weight: lighter;
                  }

                  .alt
                  {
                  font-size: medium;
                  font-weight: bold;
                  }


                  .div_title
                  {
                  /*background-color: #C0C0C0;*/
                  /*padding-left: 140px;*/
                  font-size: large;
                  align=center
                  /*font-weight: bold;*/
                  /*border : 1px inset #000000;*/
                  }


                  .div_upperright
                  {
                  font-size: medium;
                  }



                  .div_upperleft
                  {
                  font-size: medium;
                  }


                  .div_down
                  {
                  font-size: medium;
                  }


                  .div_image
                  {
                  width: 100%;
                  }


                  .sample_image
                  {
                  height : 171px;
                  border : medium double #000000;
                  }


                  .summary
                  {
                  font-size: x-large;
                  font-weight: bold;
                  }

                </style>
                                       </head>
                                       <body>
                                           <div class="main_block">
                                               <table>
                                                   <tr>
                                                       <td>
                                                           <table style="width:100%;">
                                                               <tr>
                                                                   <td id="title_block" style="width: 50%" valign="top">
                                                                       <div class="div_title" align="left">
                                                                           <span style="border: 0px outset rgb(78,63,33); ">
                                                                               <font class="alt">Specimen name:	</font>Kimberella quadrata (Glaessner,Wade,1966)</span>
                                                                           <br/>
                                                                       </div>
                                                                       <br/>
                                                                       <div class="div_upperleft">
                                                                           <span style="border: 0px outset rgb(78,63,33); ">
                                                                               <font class="alt">Size of Kimberella quadrata (Glaessner,Wade,1966):	</font>3,3x1,9cm</span>
                                                                           <br/>
                                                                           <br/>
                                                                           <span style="border: 0px outset rgb(78,63,33); ">
                                                                               <font class="alt">Block size:	</font>12,0x10,5x2,5cm</span>
                                                                           <br/>
                                                                           <span style="border: 0px outset rgb(78,63,33); ">
                                                                               <font class="alt">Net weight:	</font>0,510kg<br/><span id="bw"><font class="alt">Brutto weight:	586g<font style="font-size: x-small;">	(use this value to calculate the combine shipping [<span><a href="http://stores.ebay.com/russianfossilsandminerals/pages/rates-for-combine-shipping-usd" target="_blank">Postage rates(usd)</a>] [</span><span><a href="http://stores.ebay.com/russianfossilsandminerals/pages/rates-for-combine-shipping-eur" target="_blank">Postage rates(eur)</a></span>])</font></font></span></span>
                                                                           <br/>
                                                                       </div>
                                                                       <br/>
                                                                   </td>
                                                               </tr>
                                                               <tr>
                                                                   <td id="63"/>
                                                               </tr>
                                                               <tr>
                                                                   <td id="64"/>
                                                               </tr>
                                                               <tr>
                                                                   <td id="down_block" colspan="2">
                                                                       <div class="div_down">
                                                                           <ul>
                                                                               <li>
                                                                                   <p class="alt" style="text-decoration: underline;">Information about item: </p>
                                                                                   <span style="border: 0px outset rgb(78,63,33); ">
                                                                                       <font class="alt">Systematica:	</font>Coelenterata-> Phylum Cnidaria-> Class Cubozoa-> Order Carybdeida-> Kimberella quadrata (Glaessner,Wade,1966)</span>
                                                                                   <br/>
                                                                                   <span style="border: 0px outset rgb(78,63,33); ">
                                                                                       <font class="alt">Locality:	</font>Arkhangelsk region, Winter Coast, Erga stream</span>
                                                                                   <br/>
                                                                                   <span style="border: 0px outset rgb(78,63,33); ">
                                                                                       <font class="alt">Stratigraphy:	</font>Yorga fm</span>
                                                                                   <br/>
                                                                               </li>
                                                                           </ul>
                                                                       </div>
                                                                   </td>
                                                               </tr>
                                                           </table>
                                                       </td>
                                                       <td valign="top">
                                                           <ul>
                                                               <li>
                                                                   <a href="#shipping">Combine shipping to worldwide</a>
                                                               </li>
                                                               <li>
                                                                   <a href="#deliveryterms">Shipping terms</a>
                                                               </li>
                                                               <li>
                                                                   <a href="#parceltracking">Parcel tracking</a>
                                                               </li>
                                                               <li>
                                                                   <a href="#parcelinsurance">Parcel insurance</a>
                                                               </li>
                                                               <li>
                                                                   <a href="#damagesondelivery">Damages on delivery terms</a>
                                                               </li>
                                                               <li>
                                                                   <a href="#return">Returns and money back terms</a>
                                                               </li>
                                                               <li>
                                                                   <a href="#other">Other our items</a>
                                                               </li>
                                                           </ul>
                                                       </td>
                                                   </tr>
                                               </table>
                                               <span/>
                                               <a name="ourpolicy"/>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p class="remarks">
                All samples offered by us undergo obligatory checking for authenticity. We guarantee lack of fakes in our assortment.For all samples we try to provide the fullest and accurate information on location, geological age and the name of species. Unfortunately, in connection with a certain complexity of definition of paleontological samples various opinions in the name are possible. If you don't agree with our definition, please, contact us.
              </p>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="shipping" class="size" align="center">
                                                   <strong>WE COMBINE SH&amp;H TO WORLDWIDE</strong>
                                               </p>
                                               <p class="remarks">
                We combine shipping the items bought within one week. Buying from us more than one items, you can significantly save on shipping.
                To calculate the cost of the combined shipping, please, add up the <span><a href="#bw">brutto</a></span> weight of each item and look total shipping costs in the postage pricelist [
                <span><a href="http://stores.ebay.com/russianfossilsandminerals/pages/rates-for-combine-shipping-usd" target="_blank">Postage rates(usd)</a></span>
				]		[
                <span><a href="http://stores.ebay.com/russianfossilsandminerals/pages/rates-for-combine-shipping-eur" target="_blank">	Postage rates(eur)</a></span>].
                Please, be attentive, it is necessary to add the brutto weight of items.
              </p>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="deliveryterms" class="size" align="center">
                                                   <strong>SHIPPING TERMS</strong>
                                               </p>
                                               <p class="remarks">
                Your purchase will be shipped within 2-7 days after we receive payment.  We surely send the mail with shipping confirmation and track number. The parcel will posted necessarily with track number. We post an item with Estonian company EESTI POST, thus, when receiving a parcel outside EU additional customs payments are possible. Please, specify the amount of customs payments in your customs department.<br/></p>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="parceltracking" class="size" align="center">
                                                   <strong>PARCEL TRACKING</strong>
                                               </p>
                                               <p class="remarks">
                Typically, the time of parcel delivery, rarely exceed 14 days. In case of a delay, please, check status of delivery follow link <span><a href="http://www.track-trace.com/post" target="_blank">www.track-trace.com</a></span>. The track number you can see in the mail on confirmation of sending your purchase. In case of difficulty, please contact us specifying the track number.
              </p>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="parcelinsurance" class="size" align="center">
                                                   <strong>PARCEL INSURANCE</strong>
                                               </p>
                                               <p class="remarks">
                You can order the parcel insurance by your additional request. The cost of insurance services is 10% of a cost for parcel up to 2 kg brutto weight, and 5% of a cost for parcel more than 2 kg brutto weight. If you want to book insurance the parcel, please contact us immediately after winning the auction.
              </p>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="damagesondelivery" class="size" align="center">
                                                   <strong>DAMAGES ON DELIVERY TERMS</strong>
                                               </p>
                                               <p class="remarks">
                If in the course of delivery the item is damaged through our fault, we completely compensate the item cost, cost of shipping and cost of the return posting of an item. In this case free repair of an item and 100% compensation of postage are possible too (on your choice).
                If the item is damaged because of the post company, that, regardless of insurance existence, we will offer you FREE repair an item in our laboratory. In this case, unfortunately, we cannot compensate you postage.
                Please contact us before you leave negative feedback, and we will do our best to remedy the situation by providing a full refund of the auction price.
               </p>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="return" class="size" align="center">
                                                   <strong>RETURNS AND MONEY BACK TERMS</strong>
                                               </p>
                                               <p class="remarks">
			  We guarantee 100% money back of the purchase within 14 days of your receipt of purchase. If for whatever reason, the item that you receive does not match the auction description, we are happy to work with you on resolving the issue. Please contact us before you leave negative feedback, and we will do our best to remedy the situation by providing a full refund of the auction price. Below are the pre-conditions for refunds on returned items:
			  </p>
                                               <span class="remarks">
                                                   <ul>
                                                       <li>
			  Please return item to address shown on package.
			  </li>
                                                       <li>
			  Return item must also be in its original condition including box and packaging.
			  </li>
                                                       <li>
			  Return shipping is at the buyer's expense.
			  </li>
                                                       <li>
			  Shipping and handling is non-refundable.
			  </li>
                                                       <li>
			  Please be aware that although some of our items are offered with free shipping, our actual outbound shipping costs will be deducted from the return refund.
			  </li>
                                                       <li>
			  Refund is carried out within 3 days after we receive the sample.
			  </li>
                                                   </ul>
                                               </span>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="other" class="remarks" align="center">You may be interested in our other listings on eBay:</p>
                                               <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                   <tr>
                                                       <td>
                                                           <script language="JavaScript" type="text/javascript">
                                                               <!--
                    
                      function scrapeCat(){
                      var are = /.+\/category(\d+?)\//im; var ama = document.body.innerHTML.match(are); if (ama != null && ama.length == 2) { return ama[1]; } else { return '-1'; } }function passpara(){return '&id=1138098&itembgcolor=0xFFFFFF&bordercolor=0x000006&storewindowbgcolor=0xCEBF96&toptextcolor=0xFFFFFF&bottomtextcolor=0xFFFFFF&stripcolor=0x4E3F21&auctionclosemessagecolor=0x4E3F21&emptyboxmessagecolor=0x4E3F21&buttovercolor=0x4E3F21&buttoutcolor=0x4E3F21&searchtitlecolor=0xFFFFFF&searchbuttbgcolor=0xFFFFFF&searchbutttextcolor=0x4E3F21&searchbuttbordercolor=0xCEBF96&itemhighlightcolor=0xCEBF96&navbuttonactivecolor=0xCEBF96&navbuttonoutlinecolor=0xCEBF96&navbuttoninactivebgcolor=0xCEBF96&siteid=0&cat=' + scrapeCat() + '&baseurl='+escape(location.href.substring(0, location.href.lastIndexOf('/') + 1));
                      }
                  -->
                                                           </script>
                                                           <script language="JavaScript" type="text/javascript">
                                                               <!--
                    
                       
  var flashVersion = window.flashVersion ? window.flashVersion : 0;
  if (flashVersion <= 0)
  {
    var agent = navigator.userAgent.toLowerCase();
    if (navigator.plugins != null && navigator.plugins.length > 0) 
    { 
      var flashPlugin = navigator.plugins['Shockwave Flash']; 
      if (typeof flashPlugin == 'object') 
      {
	      /*
	      need flash version 6 or higher (this code should work with future flash plugins.)
	      */
        if (flashPlugin.description.indexOf(' 5.') != -1)
		      flashVersion = 5;  
        else if (flashPlugin.description.indexOf(' 4.') != -1)
		      flashVersion = 4;  
        else if (flashPlugin.description.indexOf(' 3.') != -1)
		      flashVersion = 3;  
        else if (flashPlugin.description.indexOf(' 2.') != -1)
		      flashVersion = 2;  
        else if (flashPlugin.description.indexOf(' 1.') != -1)
		      flashVersion = 1;  
        else  if (flashPlugin.description.indexOf(' 6.') != -1)
		      flashVersion = 6;  
        else  if (flashPlugin.description.indexOf(' 7.') != -1)
		      flashVersion = 7;  
    	  else
		      flashVersion = 8;
	    }
    }
    else if (agent.indexOf('msie') != -1 && parseInt(navigator.appVersion) >= 4 && agent.indexOf('win')!=-1 && agent.indexOf('16bit')==-1) 
    {
      if (window.sqHasFlash || typeof(window.andale_fv) != 'undefined')
      {
        if (window.sqHasFlash || andale_fv >= 6)
        {
          flashVersion = 6;
        }
      }
      else
      {
	      document.writeln('<scr' + 'ipt language="VBScript">'); 
		    document.writeln('on error resume next'); 
		    document.writeln('dim obFlash '); 
		    document.writeln('set obFlash = CreateObject("ShockwaveFlash.ShockwaveFlash.7")'); 
		    document.writeln('if IsObject(obFlash) then ');
		    document.writeln('flashVersion = 7 '); 
		    document.writeln('else set obFlash = CreateObject("ShockwaveFlash.ShockwaveFlash.6") end if ');
		    document.writeln('if flashVersion < 7 and IsObject(obFlash) then '); 
  	    document.writeln('flashVersion = 6 ');
		    document.writeln('else set obFlash = CreateObject("ShockwaveFlash.ShockwaveFlash.5") end if ');
		    document.writeln('if flashVersion < 6 and IsObject(obFlash) then '); 
		    document.writeln('flashVersion = 5 ');
		    document.writeln('else set obFlash = CreateObject("ShockwaveFlash.ShockwaveFlash.4") end if '); 
		    document.writeln('if flashVersion < 5 and IsObject(obFlash) then ');
		    document.writeln('flashVersion = 4 '); 
		    document.writeln('else set obFlash = CreateObject("ShockwaveFlash.ShockwaveFlash.3") end if ');  
		    document.writeln('if flashVersion < 4 and IsObject(obFlash) then ');  
		    document.writeln('flashVersion = 3 ');  
		    document.writeln('end if '); 
		    document.writeln('</scr' + 'ipt>');
      }
	  }
  }

  if (flashVersion >= 6)
  {
    document.writeln('<table align="center" valign="top" border="0" cellspacing="0" cellpadding="0">');document.writeln('<tr><td width="247"><tr><td align="right" valign="top">');document.writeln('<OBJECT classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" WIDTH="752" HEIGHT="320" id="auctivastorewindow" ALIGN="middle">');document.writeln('<PARAM NAME=movie VALUE="http://asw.auctiva.com/StoreWindow_Slim.swf">');document.writeln('<PARAM NAME=FlashVars VALUE="'+passpara()+'">');document.writeln('<PARAM NAME=quality VALUE=high>'); 
        document.writeln('<PARAM NAME=wmode VALUE=transparent>'); 
      document.writeln('<PARAM NAME=allowScriptAccess VALUE=always>');document.writeln('<EMBED src="http://asw.auctiva.com/StoreWindow_Slim.swf" FlashVars="'+passpara()+'"quality=high ');document.writeln('WIDTH="752" HEIGHT="320" NAME="auctivastorewindow" ALIGN="middle"');document.writeln('TYPE="application/x-shockwave-flash"');document.writeln('PLUGINSPAGE="http://www.macromedia.com/go/getflashplayer">');document.writeln('</EMBED>');
      document.writeln('</OBJECT>');		    
      document.writeln('</td></tr></table>');
    }
    else
  {document.write('<a href="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash" target="_blank"><img src="http://www.auctiva.com/images/StoreWin_NoFlashPlayer_Hor.jpg" border="0"></a><div style="text-align:center"><table align="center"><tr><td><a style="text-decoration:none" href="http://store.auctiva.com/trilbone"><img src="http://ti2.auctiva.com/sw/browse2.gif" border="0"></a></td><td height="21px" valign="middle" align="center"><font face="arial" size="2"><b><a href="http://store.auctiva.com/trilbone">trilbone</a> Store</b></font></td></tr></table></div>');}
    
    
                  -->
                                                           </script>
                                                           <noscript>
                                                               <p class="remarks" align="center">Please enable JavaScipt for view..</p>
                                                           </noscript>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </div>
                                       </body>
                                   </html>

            Return _xml
        End Get
    End Property


    Public Shared ReadOnly Property HTML_RU As XElement
        Get
            Dim _xml As XElement = <html>
                                       <head>
                                           <META http-equiv="Content-Type" content="text/html; charset=windows-1251"/>
                                           <title>Kimberella quadrata (Glaessner,Wade,1966)</title>
                                           <style type="text/css">
                  /* CSS Document */
                  /*body*/
                  .body_color {
                  background-color:#cebf96;
                  }
				.main_block {
				background-color:#d3cfb1;
				border-style: ridge;
				border-color: rgb(78,63,33);
				}
                  /*caption*/
                  .caption_sample {
                  font-family: "Bodoni MT";
                  font-size: x-large;
                  font-style: normal;
                  line-height: normal;
                  font-weight: bold;
                  color: rgb(78,63,33);
                  text-align:center;
                  vertical-align:top;
                  }

                  /*found in*/
                  .locality {
                  font-family: "Bodoni MT";
                  font-size: large;
                  font-style: normal;
                  line-height: normal;
                  font-weight: normal;
                  color: rgb(78,63,33);
                  }

                  /*age field*/
                  .age {
                  font-family: "Bodoni MT";
                  font-size: large;
                  font-style: normal;
                  line-height: normal;
                  font-weight: normal;
                  color: rgb(78,63,33);
                  background-color: #c7acbd;
                  text-align:center;
                  }

                  /*vid description*/
                  .described {
                  font-family: "Bodoni MT";
                  font-size: large;
                  font-style:normal;
                  line-height: normal;
                  font-weight: normal;
                  color: rgb(78,63,33);
                  text-align:left;
                  }

                  /*size*/
                  .size {
                  font-family: "Bodoni MT";
                  font-size: large;
                  font-style: normal;
                  line-height: normal;
                  font-weight: normal;
                  color: rgb(78,63,33);
                  }

                  /*remarks*/
                  .remarks {
                  font-family: "Bodoni MT";
                  font-size: large;
                  font-style: normal;
                  line-height: normal;
                  font-weight: normal;
                  color: rgb(78,63,33);
                  }

                  /*addtext*/
                  .addtext {
                  font-family: "Bodoni MT";
                  font-size: large;
                  font-style: normal;
                  line-height: normal;
                  font-weight: normal;
                  color: rgb(78,63,33);
                  }

                  /*barcode*/
                  .bartext {
                  font-family: "Bodoni MT";
                  font-size: 10pt;
                  font-style: normal;
                  line-height: normal;
                  font-weight: lighter;
                  color: rgb(78,63,33);
                  }

                  /*Arrow*/
                  .arrow
                  {
                  width: 20px;
                  height: 20px;
                  
         
                  }
                  
                  /*body_color*/
                  .body_color {
                  background-color:#cebf96;
                  font-family: "Bodoni MT";
                  line-height: normal;
                  font-size:small;
                  color: rgb(78,63,33);
                  }



                  .hr_sample{
                  height: 5px;
                  background-color: rgb(78,63,33);
                  }



                  .hr_catalog{
                  height: 7px;
                  background-color: rgb(78,63,33);
                  }



                  .caption_catalog {
                  background-color: #C0C0C0;
                  font-size: x-large;
                  font-weight: bold;
                  text-align:center;
                  vertical-align:top;
                  }



                  .div_main
                  {
                  display:block;
                  left: 5%;
                  top: 0px;
                  height: 100%;
                  }


                  .NUMBER
                  {
                  font-size: x-small;
                  font-weight: lighter;
                  }

                  .alt
                  {
                  font-size: medium;
                  font-weight: bold;
                  }


                  .div_title
                  {
                  /*background-color: #C0C0C0;*/
                  /*padding-left: 140px;*/
                  font-size: large;
                  align=center
                  /*font-weight: bold;*/
                  /*border : 1px inset #000000;*/
                  }


                  .div_upperright
                  {
                  font-size: medium;
                  }



                  .div_upperleft
                  {
                  font-size: medium;
                  }


                  .div_down
                  {
                  font-size: medium;
                  }


                  .div_image
                  {
                  width: 100%;
                  }


                  .sample_image
                  {
                  height : 171px;
                  border : medium double #000000;
                  }


                  .summary
                  {
                  font-size: x-large;
                  font-weight: bold;
                  }

                </style>
                                       </head>
                                       <body>
                                           <div class="main_block">
                                               <table>
                                                   <tr>
                                                       <td>
                                                           <table style="width:100%;">
                                                               <tr>
                                                                   <td id="title_block" style="width: 50%" valign="top">
                                                                       <div class="div_title" align="left">
                                                                           <span style="border: 0px outset rgb(78,63,33); ">
                                                                               <font class="alt">Название:	</font>Kimberella quadrata (Glaessner,Wade,1966)</span>
                                                                           <br/>
                                                                       </div>
                                                                       <br/>
                                                                       <div class="div_upperleft">
                                                                           <span style="border: 0px outset rgb(78,63,33); ">
                                                                               <font class="alt">Размер Kimberella quadrata (Glaessner,Wade,1966):	</font>3,3x1,9см</span>
                                                                           <br/>
                                                                           <br/>
                                                                           <span style="border: 0px outset rgb(78,63,33); ">
                                                                               <font class="alt">Размер блока:	</font>12,0x10,5x2,5см</span>
                                                                           <br/>
                                                                           <span style="border: 0px outset rgb(78,63,33); ">
                                                                               <font class="alt">Вес образца:	</font>0,510кг<br/><span id="bw"><font class="alt">Brutto weight:	<font style="font-size: x-small;">use Net weight + 20% to calculate the combine shipping [<span><a href="http://stores.ebay.com/russianfossilsandminerals/pages/rates-for-combine-shipping-usd" target="_blank">Postage rates(usd)</a>] [</span><span><a href="http://stores.ebay.com/russianfossilsandminerals/pages/rates-for-combine-shipping-eur" target="_blank">Postage rates(eur)</a></span>])</font></font></span></span>
                                                                           <br/>
                                                                       </div>
                                                                       <br/>
                                                                   </td>
                                                               </tr>
                                                               <tr>
                                                                   <td id="63"/>
                                                               </tr>
                                                               <tr>
                                                                   <td id="64"/>
                                                               </tr>
                                                               <tr>
                                                                   <td id="down_block" colspan="2">
                                                                       <div class="div_down">
                                                                           <ul>
                                                                               <li>
                                                                                   <p class="alt" style="text-decoration: underline;">Information about item: </p>
                                                                                   <span style="border: 0px outset rgb(78,63,33); ">
                                                                                       <font class="alt">Систематика:	</font>Кишечнополостные-> Тип Стрекающие-> Класс Кубомедузы-> Order Carybdeida-> Kimberella quadrata (Glaessner,Wade,1966)</span>
                                                                                   <br/>
                                                                                   <span style="border: 0px outset rgb(78,63,33); ">
                                                                                       <font class="alt">Местонахождение:	</font>Архангельск, Зимний Берег, ручей Ерга</span>
                                                                                   <br/>
                                                                                   <span style="border: 0px outset rgb(78,63,33); ">
                                                                                       <font class="alt">Стратиграфия:	</font>Егринская свита</span>
                                                                                   <br/>
                                                                               </li>
                                                                           </ul>
                                                                       </div>
                                                                   </td>
                                                               </tr>
                                                           </table>
                                                       </td>
                                                       <td valign="top">
                                                           <ul>
                                                               <li>
                                                                   <a href="#shipping">Combine shipping to worldwide</a>
                                                               </li>
                                                               <li>
                                                                   <a href="#deliveryterms">Shipping terms</a>
                                                               </li>
                                                               <li>
                                                                   <a href="#parceltracking">Parcel tracking</a>
                                                               </li>
                                                               <li>
                                                                   <a href="#parcelinsurance">Parcel insurance</a>
                                                               </li>
                                                               <li>
                                                                   <a href="#damagesondelivery">Damages on delivery terms</a>
                                                               </li>
                                                               <li>
                                                                   <a href="#return">Returns and money back terms</a>
                                                               </li>
                                                               <li>
                                                                   <a href="#other">Other our items</a>
                                                               </li>
                                                           </ul>
                                                       </td>
                                                   </tr>
                                               </table>
                                               <span/>
                                               <a name="ourpolicy"/>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p class="remarks">
                All samples offered by us undergo obligatory checking for authenticity. We guarantee lack of fakes in our assortment.For all samples we try to provide the fullest and accurate information on location, geological age and the name of species. Unfortunately, in connection with a certain complexity of definition of paleontological samples various opinions in the name are possible. If you don't agree with our definition, please, contact us.
              </p>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="shipping" class="size" align="center">
                                                   <strong>WE COMBINE SH&amp;H TO WORLDWIDE</strong>
                                               </p>
                                               <p class="remarks">
                We combine shipping the items bought within one week. Buying from us more than one items, you can significantly save on shipping.
                To calculate the cost of the combined shipping, please, add up the <span><a href="#bw">brutto</a></span> weight of each item and look total shipping costs in the postage pricelist [
                <span><a href="http://stores.ebay.com/russianfossilsandminerals/pages/rates-for-combine-shipping-usd" target="_blank">Postage rates(usd)</a></span>
				]		[
                <span><a href="http://stores.ebay.com/russianfossilsandminerals/pages/rates-for-combine-shipping-eur" target="_blank">	Postage rates(eur)</a></span>].
                Please, be attentive, it is necessary to add the brutto weight of items.
              </p>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="deliveryterms" class="size" align="center">
                                                   <strong>SHIPPING TERMS</strong>
                                               </p>
                                               <p class="remarks">
                Your purchase will be shipped within 2-7 days after we receive payment.  We surely send the mail with shipping confirmation and track number. The parcel will posted necessarily with track number. We post an item with Estonian company EESTI POST, thus, when receiving a parcel outside EU additional customs payments are possible. Please, specify the amount of customs payments in your customs department.<br/></p>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="parceltracking" class="size" align="center">
                                                   <strong>PARCEL TRACKING</strong>
                                               </p>
                                               <p class="remarks">
                Typically, the time of parcel delivery, rarely exceed 14 days. In case of a delay, please, check status of delivery follow link <span><a href="http://www.track-trace.com/post" target="_blank">www.track-trace.com</a></span>. The track number you can see in the mail on confirmation of sending your purchase. In case of difficulty, please contact us specifying the track number.
              </p>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="parcelinsurance" class="size" align="center">
                                                   <strong>PARCEL INSURANCE</strong>
                                               </p>
                                               <p class="remarks">
                You can order the parcel insurance by your additional request. The cost of insurance services is 10% of a cost for parcel up to 2 kg brutto weight, and 5% of a cost for parcel more than 2 kg brutto weight. If you want to book insurance the parcel, please contact us immediately after winning the auction.
              </p>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="damagesondelivery" class="size" align="center">
                                                   <strong>DAMAGES ON DELIVERY TERMS</strong>
                                               </p>
                                               <p class="remarks">
                If in the course of delivery the item is damaged through our fault, we completely compensate the item cost, cost of shipping and cost of the return posting of an item. In this case free repair of an item and 100% compensation of postage are possible too (on your choice).
                If the item is damaged because of the post company, that, regardless of insurance existence, we will offer you FREE repair an item in our laboratory. In this case, unfortunately, we cannot compensate you postage.
                Please contact us before you leave negative feedback, and we will do our best to remedy the situation by providing a full refund of the auction price.
               </p>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="return" class="size" align="center">
                                                   <strong>RETURNS AND MONEY BACK TERMS</strong>
                                               </p>
                                               <p class="remarks">
			  We guarantee 100% money back of the purchase within 14 days of your receipt of purchase. If for whatever reason, the item that you receive does not match the auction description, we are happy to work with you on resolving the issue. Please contact us before you leave negative feedback, and we will do our best to remedy the situation by providing a full refund of the auction price. Below are the pre-conditions for refunds on returned items:
			  </p>
                                               <span class="remarks">
                                                   <ul>
                                                       <li>
			  Please return item to address shown on package.
			  </li>
                                                       <li>
			  Return item must also be in its original condition including box and packaging.
			  </li>
                                                       <li>
			  Return shipping is at the buyer's expense.
			  </li>
                                                       <li>
			  Shipping and handling is non-refundable.
			  </li>
                                                       <li>
			  Please be aware that although some of our items are offered with free shipping, our actual outbound shipping costs will be deducted from the return refund.
			  </li>
                                                       <li>
			  Refund is carried out within 3 days after we receive the sample.
			  </li>
                                                   </ul>
                                               </span>
                                               <hr style="height: 7px; background-color: rgb(78,63,33);"/>
                                               <p id="other" class="remarks" align="center">You may be interested in our other listings on eBay:</p>
                                               <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                   <tr>
                                                       <td>
                                                           <script language="JavaScript" type="text/javascript">
                                                               <!--
                    
                      function scrapeCat(){
                      var are = /.+\/category(\d+?)\//im; var ama = document.body.innerHTML.match(are); if (ama != null && ama.length == 2) { return ama[1]; } else { return '-1'; } }function passpara(){return '&id=1138098&itembgcolor=0xFFFFFF&bordercolor=0x000006&storewindowbgcolor=0xCEBF96&toptextcolor=0xFFFFFF&bottomtextcolor=0xFFFFFF&stripcolor=0x4E3F21&auctionclosemessagecolor=0x4E3F21&emptyboxmessagecolor=0x4E3F21&buttovercolor=0x4E3F21&buttoutcolor=0x4E3F21&searchtitlecolor=0xFFFFFF&searchbuttbgcolor=0xFFFFFF&searchbutttextcolor=0x4E3F21&searchbuttbordercolor=0xCEBF96&itemhighlightcolor=0xCEBF96&navbuttonactivecolor=0xCEBF96&navbuttonoutlinecolor=0xCEBF96&navbuttoninactivebgcolor=0xCEBF96&siteid=0&cat=' + scrapeCat() + '&baseurl='+escape(location.href.substring(0, location.href.lastIndexOf('/') + 1));
                      }
                  -->
                                                           </script>
                                                           <script language="JavaScript" type="text/javascript">
                                                               <!--
                    
                       
  var flashVersion = window.flashVersion ? window.flashVersion : 0;
  if (flashVersion <= 0)
  {
    var agent = navigator.userAgent.toLowerCase();
    if (navigator.plugins != null && navigator.plugins.length > 0) 
    { 
      var flashPlugin = navigator.plugins['Shockwave Flash']; 
      if (typeof flashPlugin == 'object') 
      {
	      /*
	      need flash version 6 or higher (this code should work with future flash plugins.)
	      */
        if (flashPlugin.description.indexOf(' 5.') != -1)
		      flashVersion = 5;  
        else if (flashPlugin.description.indexOf(' 4.') != -1)
		      flashVersion = 4;  
        else if (flashPlugin.description.indexOf(' 3.') != -1)
		      flashVersion = 3;  
        else if (flashPlugin.description.indexOf(' 2.') != -1)
		      flashVersion = 2;  
        else if (flashPlugin.description.indexOf(' 1.') != -1)
		      flashVersion = 1;  
        else  if (flashPlugin.description.indexOf(' 6.') != -1)
		      flashVersion = 6;  
        else  if (flashPlugin.description.indexOf(' 7.') != -1)
		      flashVersion = 7;  
    	  else
		      flashVersion = 8;
	    }
    }
    else if (agent.indexOf('msie') != -1 && parseInt(navigator.appVersion) >= 4 && agent.indexOf('win')!=-1 && agent.indexOf('16bit')==-1) 
    {
      if (window.sqHasFlash || typeof(window.andale_fv) != 'undefined')
      {
        if (window.sqHasFlash || andale_fv >= 6)
        {
          flashVersion = 6;
        }
      }
      else
      {
	      document.writeln('<scr' + 'ipt language="VBScript">'); 
		    document.writeln('on error resume next'); 
		    document.writeln('dim obFlash '); 
		    document.writeln('set obFlash = CreateObject("ShockwaveFlash.ShockwaveFlash.7")'); 
		    document.writeln('if IsObject(obFlash) then ');
		    document.writeln('flashVersion = 7 '); 
		    document.writeln('else set obFlash = CreateObject("ShockwaveFlash.ShockwaveFlash.6") end if ');
		    document.writeln('if flashVersion < 7 and IsObject(obFlash) then '); 
  	    document.writeln('flashVersion = 6 ');
		    document.writeln('else set obFlash = CreateObject("ShockwaveFlash.ShockwaveFlash.5") end if ');
		    document.writeln('if flashVersion < 6 and IsObject(obFlash) then '); 
		    document.writeln('flashVersion = 5 ');
		    document.writeln('else set obFlash = CreateObject("ShockwaveFlash.ShockwaveFlash.4") end if '); 
		    document.writeln('if flashVersion < 5 and IsObject(obFlash) then ');
		    document.writeln('flashVersion = 4 '); 
		    document.writeln('else set obFlash = CreateObject("ShockwaveFlash.ShockwaveFlash.3") end if ');  
		    document.writeln('if flashVersion < 4 and IsObject(obFlash) then ');  
		    document.writeln('flashVersion = 3 ');  
		    document.writeln('end if '); 
		    document.writeln('</scr' + 'ipt>');
      }
	  }
  }

  if (flashVersion >= 6)
  {
    document.writeln('<table align="center" valign="top" border="0" cellspacing="0" cellpadding="0">');document.writeln('<tr><td width="247"><tr><td align="right" valign="top">');document.writeln('<OBJECT classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" WIDTH="752" HEIGHT="320" id="auctivastorewindow" ALIGN="middle">');document.writeln('<PARAM NAME=movie VALUE="http://asw.auctiva.com/StoreWindow_Slim.swf">');document.writeln('<PARAM NAME=FlashVars VALUE="'+passpara()+'">');document.writeln('<PARAM NAME=quality VALUE=high>'); 
        document.writeln('<PARAM NAME=wmode VALUE=transparent>'); 
      document.writeln('<PARAM NAME=allowScriptAccess VALUE=always>');document.writeln('<EMBED src="http://asw.auctiva.com/StoreWindow_Slim.swf" FlashVars="'+passpara()+'"quality=high ');document.writeln('WIDTH="752" HEIGHT="320" NAME="auctivastorewindow" ALIGN="middle"');document.writeln('TYPE="application/x-shockwave-flash"');document.writeln('PLUGINSPAGE="http://www.macromedia.com/go/getflashplayer">');document.writeln('</EMBED>');
      document.writeln('</OBJECT>');		    
      document.writeln('</td></tr></table>');
    }
    else
  {document.write('<a href="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash" target="_blank"><img src="http://www.auctiva.com/images/StoreWin_NoFlashPlayer_Hor.jpg" border="0"></a><div style="text-align:center"><table align="center"><tr><td><a style="text-decoration:none" href="http://store.auctiva.com/trilbone"><img src="http://ti2.auctiva.com/sw/browse2.gif" border="0"></a></td><td height="21px" valign="middle" align="center"><font face="arial" size="2"><b><a href="http://store.auctiva.com/trilbone">trilbone</a> Store</b></font></td></tr></table></div>');}
    
    
                  -->
                                                           </script>
                                                           <noscript>
                                                               <p class="remarks" align="center">Please enable JavaScipt for view..</p>
                                                           </noscript>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </div>
                                       </body>
                                   </html>

            Return _xml
        End Get
    End Property



    Public Shared ReadOnly Property XMLDescription As XElement
        Get
            Dim _xml As XElement = <DATA>
                                       <ELEMENT filename="Vend.tree" name="Systematica" root="Systematica" lang="en-US" id="456">
                                           <NODE order="1" nodeid="538">Coelenterata</NODE>
                                           <NODE order="2" nodeid="539">Phylum Cnidaria</NODE>
                                           <NODE order="3" nodeid="547">Class Cubozoa</NODE>
                                           <NODE order="4" nodeid="548">Order Carybdeida</NODE>
                                           <NODE order="5" nodeid="456">Kimberella quadrata (Glaessner,Wade,1966)<INFO>Ovate bodies, rounded at one end and with a smooth contour; internal 
structures represented by several longitudinal, distinct zones of two kinds, coarsely 
segmented or with fine, transverse, frill-like grooves bordering a smooth area. 
</INFO><LINKS><LINK treename="Locality"><NODEID value="429"></NODEID><NODEID value="430"></NODEID><NODEID value="431"></NODEID></LINK><LINK treename="Stratigraphy"><NODEID value="437"></NODEID><NODEID value="439"></NODEID></LINK></LINKS></NODE>
                                       </ELEMENT>
                                       <ELEMENT filename="Vend.tree" name="Systematica" root="Систематика" lang="ru-RU" id="456">
                                           <NODE order="1" nodeid="538">Кишечнополостные</NODE>
                                           <NODE order="2" nodeid="539">Тип Стрекающие</NODE>
                                           <NODE order="3" nodeid="547">Класс Кубомедузы</NODE>
                                           <NODE order="4" nodeid="548">Order Carybdeida</NODE>
                                           <NODE order="5" nodeid="456">Kimberella quadrata (Glaessner,Wade,1966)<INFO>Ovate bodies, rounded at one end and with a smooth contour; internal 
structures represented by several longitudinal, distinct zones of two kinds, coarsely 
segmented or with fine, transverse, frill-like grooves bordering a smooth area. 
</INFO><LINKS><LINK treename="Locality"><NODEID value="429"></NODEID><NODEID value="430"></NODEID><NODEID value="431"></NODEID></LINK><LINK treename="Stratigraphy"><NODEID value="437"></NODEID><NODEID value="439"></NODEID></LINK></LINKS></NODE>
                                       </ELEMENT>
                                       <ELEMENT filename="Vend.tree" name="Locality" root="Locality" lang="en-US" id="431">
                                           <NODE order="1" nodeid="426">Arkhangelsk region</NODE>
                                           <NODE order="2" nodeid="428">Winter Coast</NODE>
                                           <NODE order="3" nodeid="431">Erga stream<LINKS><LINK treename="Systematica"><NODEID value="451"></NODEID><NODEID value="452"></NODEID><NODEID value="447"></NODEID><NODEID value="456"></NODEID><NODEID value="443"></NODEID><NODEID value="448"></NODEID><NODEID value="459"></NODEID><NODEID value="461"></NODEID><NODEID value="457"></NODEID><NODEID value="487"></NODEID><NODEID value="584"></NODEID><NODEID value="467"></NODEID><NODEID value="526"></NODEID><NODEID value="453"></NODEID><NODEID value="449"></NODEID><NODEID value="524"></NODEID><NODEID value="484"></NODEID><NODEID value="587"></NODEID><NODEID value="445"></NODEID><NODEID value="483"></NODEID><NODEID value="586"></NODEID><NODEID value="591"></NODEID><NODEID value="595"></NODEID><NODEID value="575"></NODEID><NODEID value="574"></NODEID><NODEID value="589"></NODEID><NODEID value="605"></NODEID><NODEID value="593"></NODEID></LINK><LINK treename="Stratigraphy"><NODEID value="439"></NODEID><NODEID value="440"></NODEID></LINK></LINKS></NODE>
                                       </ELEMENT>
                                       <ELEMENT filename="Vend.tree" name="Locality" root="Местонахождение" lang="ru-RU" id="431">
                                           <NODE order="1" nodeid="426">Архангельск</NODE>
                                           <NODE order="2" nodeid="428">Зимний Берег</NODE>
                                           <NODE order="3" nodeid="431">ручей Ерга<LINKS><LINK treename="Systematica"><NODEID value="451"></NODEID><NODEID value="452"></NODEID><NODEID value="447"></NODEID><NODEID value="456"></NODEID><NODEID value="443"></NODEID><NODEID value="448"></NODEID><NODEID value="459"></NODEID><NODEID value="461"></NODEID><NODEID value="457"></NODEID><NODEID value="487"></NODEID><NODEID value="584"></NODEID><NODEID value="467"></NODEID><NODEID value="526"></NODEID><NODEID value="453"></NODEID><NODEID value="449"></NODEID><NODEID value="524"></NODEID><NODEID value="484"></NODEID><NODEID value="587"></NODEID><NODEID value="445"></NODEID><NODEID value="483"></NODEID><NODEID value="586"></NODEID><NODEID value="591"></NODEID><NODEID value="595"></NODEID><NODEID value="575"></NODEID><NODEID value="574"></NODEID><NODEID value="589"></NODEID><NODEID value="605"></NODEID><NODEID value="593"></NODEID></LINK><LINK treename="Stratigraphy"><NODEID value="439"></NODEID><NODEID value="440"></NODEID></LINK></LINKS></NODE>
                                       </ELEMENT>
                                       <ELEMENT filename="Vend.tree" name="Stratigraphy" root="Stratigraphy" lang="en-US" id="439">
                                           <NODE order="1" nodeid="439">Yorga fm<LINKS><LINK treename="Locality"><NODEID value="431"></NODEID></LINK><LINK treename="Systematica"><NODEID value="456"></NODEID><NODEID value="443"></NODEID><NODEID value="448"></NODEID><NODEID value="459"></NODEID><NODEID value="461"></NODEID><NODEID value="457"></NODEID><NODEID value="526"></NODEID><NODEID value="453"></NODEID><NODEID value="524"></NODEID><NODEID value="484"></NODEID><NODEID value="587"></NODEID><NODEID value="483"></NODEID><NODEID value="487"></NODEID><NODEID value="586"></NODEID><NODEID value="449"></NODEID><NODEID value="575"></NODEID><NODEID value="574"></NODEID><NODEID value="589"></NODEID><NODEID value="605"></NODEID><NODEID value="593"></NODEID><NODEID value="451"></NODEID></LINK></LINKS></NODE>
                                       </ELEMENT>
                                       <ELEMENT filename="Vend.tree" name="Stratigraphy" root="Стратиграфия" lang="ru-RU" id="439">
                                           <NODE order="1" nodeid="439">Егринская свита<LINKS><LINK treename="Locality"><NODEID value="431"></NODEID></LINK><LINK treename="Systematica"><NODEID value="456"></NODEID><NODEID value="443"></NODEID><NODEID value="448"></NODEID><NODEID value="459"></NODEID><NODEID value="461"></NODEID><NODEID value="457"></NODEID><NODEID value="526"></NODEID><NODEID value="453"></NODEID><NODEID value="524"></NODEID><NODEID value="484"></NODEID><NODEID value="587"></NODEID><NODEID value="483"></NODEID><NODEID value="487"></NODEID><NODEID value="586"></NODEID><NODEID value="449"></NODEID><NODEID value="575"></NODEID><NODEID value="574"></NODEID><NODEID value="589"></NODEID><NODEID value="605"></NODEID><NODEID value="593"></NODEID><NODEID value="451"></NODEID></LINK></LINKS></NODE>
                                       </ELEMENT>
                                   </DATA>

            Return _xml
        End Get
    End Property


    'Public Shared ReadOnly Property XMLlabel As XElement
    '    Get
    '        Dim _xml As XElement = <DATA>
    '                                   <LABELINFO id="1683246433" group="MRTrilobites.tree" treename="Systematica" rootnode="Systematica" nodeid="321" order="1" lang="en-US">class Trilobita (Walch 1771), order Proetida (Fortey &amp;amp; Owens, 1975), suborder Proetina (Fortey &amp;amp; Owens 1975), superfamily Proetoidea (Hawle &amp;amp; Corda, 1847), family Proetidae (Salter, 1864), subfamily Proetinae (HAWLE &amp;amp; CORDA, 1847), genus Gerastos (Goldfuss, 1843), Gerastos granulosus (Goldfuss, 1843)</LABELINFO>

    '                                   <LABELINFO id="-1064547380" group="MRTrilobites.tree" treename="Systematica" rootnode="Систематика" nodeid="321" order="1" lang="ru-RU">Класс Trilobita (Walch 1771),  отряд Proetida (Fortey &amp;amp; Owens, 1975),  подотряд Proetina (Fortey &amp;amp; Owens 1975), надсемейство Proetoidea (Hawle &amp;amp; Corda, 1847), семейство Proetidae (Salter, 1864), subfamily Proetinae (HAWLE &amp;amp; CORDA, 1847),  род Gerastos (Goldfuss, 1843), Gerastos granulosus (Goldfuss, 1843)</LABELINFO>

    '                                   <LABELINFO id="1347615846" group="MRTrilobites.tree" treename="TimeScale" rootnode="TimeScale" nodeid="269" order="2" lang="en-US">Devonian, middle devonian (393.3 – 382.7 Ma), Eifelian stage(393.3 – 387.7 Ma)</LABELINFO>

    '                                   <LABELINFO id="-192218421" group="MRTrilobites.tree" treename="TimeScale" rootnode="Геологический возраст" nodeid="269" order="2" lang="ru-RU">девон, средний девон (393.3 – 382.7 млн.лет), Эйфельский ярус(393.3 – 387.7 млн.лет)</LABELINFO>

    '                                   <LABELINFO id="1633921593" group="MRTrilobites.tree" treename="Locality" rootnode="Locality" nodeid="326" order="3" lang="en-US">Germany, Eifel Region, Ahrdorf formation</LABELINFO>

    '                                   <LABELINFO id="-977556332" group="MRTrilobites.tree" treename="Locality" rootnode="Местонахождение" nodeid="326" order="3" lang="ru-RU">Германия, район Эйфель, формация Ahrdorf</LABELINFO>

    '                                   <LABEL id="-1064547380" group="MRTrilobites.tree" lang="en-US">
    '                                       <NODE order="1" treename="Systematica" rootnode="Systematica" combined="False">
    '                                           <NODEID labelinfoid="1683246433" nodeid="321"></NODEID>class Trilobita (Walch 1771), order Proetida (Fortey &amp;amp; Owens, 1975), suborder Proetina (Fortey &amp;amp; Owens 1975), superfamily Proetoidea (Hawle &amp;amp; Corda, 1847), family Proetidae (Salter, 1864), subfamily Proetinae (HAWLE &amp;amp; CORDA, 1847), genus Gerastos (Goldfuss, 1843), Gerastos granulosus (Goldfuss, 1843)</NODE>
    '                                       <NODE order="2" treename="TimeScale" rootnode="TimeScale" combined="False">
    '                                           <NODEID labelinfoid="1347615846" nodeid="269"></NODEID>Devonian, middle devonian (393.3 – 382.7 Ma), Eifelian stage(393.3 – 387.7 Ma)</NODE>
    '                                       <NODE order="3" treename="Locality" rootnode="Locality" combined="False">
    '                                           <NODEID labelinfoid="1633921593" nodeid="326"></NODEID>Germany, Eifel Region, Ahrdorf formation</NODE>
    '                                   </LABEL>

    '                                   <LABEL id="-1064547380" group="MRTrilobites.tree" lang="ru-RU">
    '                                       <NODE order="1" treename="Systematica" rootnode="Систематика" combined="False">
    '                                           <NODEID labelinfoid="-1064547380" nodeid="321"></NODEID>Класс Trilobita (Walch 1771),  отряд Proetida (Fortey &amp;amp; Owens, 1975),  подотряд Proetina (Fortey &amp;amp; Owens 1975), надсемейство Proetoidea (Hawle &amp;amp; Corda, 1847), семейство Proetidae (Salter, 1864), subfamily Proetinae (HAWLE &amp;amp; CORDA, 1847),  род Gerastos (Goldfuss, 1843), Gerastos granulosus (Goldfuss, 1843)</NODE>
    '                                       <NODE order="2" treename="TimeScale" rootnode="Геологический возраст" combined="False">
    '                                           <NODEID labelinfoid="-192218421" nodeid="269"></NODEID>девон, средний девон (393.3 – 382.7 млн.лет), Эйфельский ярус(393.3 – 387.7 млн.лет)</NODE>
    '                                       <NODE order="3" treename="Locality" rootnode="Местонахождение" combined="False">
    '                                           <NODEID labelinfoid="-977556332" nodeid="326"></NODEID>Германия, район Эйфель, формация Ahrdorf</NODE>
    '                                   </LABEL>

    '                               </DATA>

    '        Return _xml
    '    End Get
    'End Property


    Public Shared ReadOnly Property XMLmap As XDocument()
        Get
            Dim _xmlru As XDocument = <?xml version="1.0" encoding="utf-16"?>
                                      <CATALOGSAMPLE xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" bar="8029000039195" version="2">
                                          <DATA>
                                              <ELEMENT hash="866403103" name="NUMBER" order="1" alt="false" position="down" border="0" underline="false">8-3919</ELEMENT>
                                              <ELEMENT hash="166102198" name="NAME" order="1" alt="Название" position="title" border="0" underline="false">Kimberella quadrata (Glaessner,Wade,1966)</ELEMENT>
                                              <ELEMENT hash="1616768535" name="MATRIXSIZE" order="1" alt="Размер блока" position="upperright" border="0" underline="false">12,0x10,5x2,5см</ELEMENT>
                                              <ELEMENT hash="-1425509410" name="WEIGHT" order="2" alt="Вес образца" position="upperright" border="0" underline="false">0,510кг</ELEMENT>
                                              <ELEMENT hash="-1290558020" name="FOSSILSIZE" order="1" alt="Размер Kimberella quadrata (Glaessner,Wade,1966)" position="upperleft" border="0" underline="false">3,3x1,9см</ELEMENT>
                                              <ELEMENT hash="-644082694" name="SYSTEMATICA" order="2" alt="Систематика" position="down" border="0" underline="false">Кишечнополостные-&gt; Тип Стрекающие-&gt; Класс Кубомедузы-&gt; Order Carybdeida-&gt; Kimberella quadrata (Glaessner,Wade,1966)</ELEMENT>
                                              <ELEMENT hash="342235036" name="LOCALITY" order="3" alt="Местонахождение" position="down" border="0" underline="false">Архангельск, Зимний Берег, ручей Ерга</ELEMENT>
                                              <ELEMENT hash="447012101" name="STRATIGRAPHY" order="4" alt="Стратиграфия" position="down" border="0" underline="false">Егринская свита</ELEMENT>
                                          </DATA>
                                          <IMAGES>
                                              <IMAGE src="1-IMG_4328.JPG"/>
                                              <IMAGE src="2-IMG_4313.JPG"/>
                                              <IMAGE src="3-IMG_4331.JPG"/>
                                          </IMAGES>
                                      </CATALOGSAMPLE>





            Dim _xmlen As XDocument = <?xml version="1.0" encoding="utf-16"?>
                                      <CATALOGSAMPLE xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" bar="8029000039195" version="2">
                                          <DATA>
                                              <ELEMENT hash="866403103" name="NUMBER" order="1" alt="false" position="down" border="0" underline="false">8-3919</ELEMENT>
                                              <ELEMENT hash="593227003" name="NAME" order="1" alt="Specimen name" position="title" border="0" underline="false">Kimberella quadrata (Glaessner,Wade,1966)</ELEMENT>
                                              <ELEMENT hash="-950224312" name="MATRIXSIZE" order="1" alt="Block size" position="upperright" border="0" underline="false">12,0x10,5x2,5cm</ELEMENT>
                                              <ELEMENT hash="746245437" name="WEIGHT" order="2" alt="Net weight" position="upperright" border="0" underline="false">0,510kg</ELEMENT>
                                              <ELEMENT hash="1038112780" name="FOSSILSIZE" order="1" alt="Size of Kimberella quadrata (Glaessner,Wade,1966)" position="upperleft" border="0" underline="false">3,3x1,9cm</ELEMENT>
                                              <ELEMENT hash="1925064812" name="SYSTEMATICA" order="2" alt="Systematica" position="down" border="0" underline="false">Coelenterata-&gt; Phylum Cnidaria-&gt; Class Cubozoa-&gt; Order Carybdeida-&gt; Kimberella quadrata (Glaessner,Wade,1966)</ELEMENT>
                                              <ELEMENT hash="2005553651" name="LOCALITY" order="3" alt="Locality" position="down" border="0" underline="false">Arkhangelsk region, Winter Coast, Erga stream</ELEMENT>
                                              <ELEMENT hash="-1283930462" name="STRATIGRAPHY" order="4" alt="Stratigraphy" position="down" border="0" underline="false">Yorga fm</ELEMENT>
                                          </DATA>
                                          <IMAGES>
                                              <IMAGE src="1-IMG_4328.JPG"/>
                                              <IMAGE src="2-IMG_4313.JPG"/>
                                              <IMAGE src="3-IMG_4331.JPG"/>
                                          </IMAGES>
                                      </CATALOGSAMPLE>


            Return {_xmlru, _xmlen}
        End Get
    End Property
End Class