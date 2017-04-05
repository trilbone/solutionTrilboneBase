<?xml version='1.0'?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="html" encoding="windows-1251" indent="yes" />
  <!--корневой путь  -->
  <xsl:variable name="root">http://www.trilbone.com/</xsl:variable>
  <xsl:variable name="image-dir">images</xsl:variable>
  <xsl:variable name="hiresimage-dir">high</xsl:variable>
  <xsl:variable name="lowimage-dir">low</xsl:variable>
  <xsl:variable name="titleimage-dir">title</xsl:variable>

  <xsl:template match="/">
    <html>
      <body class="body_color">
        <table class="body_color" style='border-style: ridge; border-color: rgb(78,63,33);'>
          <style type="text/css">
            /* CSS Document */
            /* цвет страницы */
            .body_color {
            background-color:#cebf96;
            }
            /*заголовок названия*/
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
            .arrow
            {
            width: 38px;
            height: 33px;
            z-index: auto;
            position: relative;
            }
          </style>
          <tr>
            <td>
              <!--Left menu and logo = caption-->
              <!--block of menu-->
              <div  style=" display: block; float: left; top: 0px; left: 0px;
         position: relative; padding-top: 10px; visibility: visible; ">
                <!--caption-->
                <p class="bartext" align="center" style="position: relative; display: block; clip: 
                          rect(auto, auto, auto, 20px)">
                  <strong>Quick links:</strong>
                </p>
                <!--list-->
                <ul>
                  <li class="bartext"  >
                    <a href="#size">Size and locality</a>
                  </li>
                  <li class="bartext" >
                    <a href="#about">About trilobites</a>
                  </li>
                  <li class="bartext" >
                    <a href="#shipping">Payment and shipping</a>
                  </li>
                  <li class="bartext" >
                    <a href="#other">Other trilobites</a>
                  </li>
                </ul>
              </div>
              <!--block of logo-->
              <div style=" display: block; float: left; top: 0px; left: 90px;
         position: relative; visibility: visible; " >
                <!--logo image-->
                <p align="center">
                  <img border="0" src="{$root}logo_ordovician.gif"/>
                </p>
              </div>

              <!--select tamplate sample-->
              <xsl:apply-templates select="//SAMPLE"></xsl:apply-templates>

              <!--
              <xsl:choose>
                <xsl:when test="substring(/SAMPLE/@bar,1,3)='220'">
                  <xsl:apply-templates select="//SAMPLE"></xsl:apply-templates>

                </xsl:when>
                <xsl:otherwise>
                  <xsl:apply-templates select="//SAMPLE"></xsl:apply-templates>
                
                </xsl:otherwise>

              </xsl:choose>
              -->

            </td>
          </tr>
          <tr>
            <!--other info-->
            <td>
              <!--ancor-->
              <a name="about"></a>
              <!--ancor-->
              <hr style='height: 7px; background-color: rgb(78,63,33);'/>
              <p class='size' align='center'>
                <strong>ABOUT TRILOBITES</strong>
              </p>
              <p class='remarks'>
                Trilobites ("three-lobes") are extinct marine arthropods that form the class Trilobita. They appeared in the Early Cambrian period and flourished throughout the lower Paleozoic era before beginning a drawn-out decline to extinction when, during the Late Devonian extinction, all trilobite orders, with the sole exception of Proetida, died out. The last of the trilobites disappeared in the mass extinction at the end of the Permian about 250 million years ago (m.y.a.).
                Trilobites are very well-known, and possibly the second-most famous fossil group, after the dinosaurs. When trilobites appear in the fossil record of the Lower Cambrian they were already highly diverse and geographically dispersed. Because of their diversity and an easily fossilized exoskeleton, they left an extensive fossil record with some 17,000 known species spanning Paleozoic time. Trilobites have been important in biostratigraphy, paleontology, and plate tectonics research.
              </p>
              <p class='remarks'>
                Russian Ordovician trilobites are very well-known collectible fossils.These trilobites are all absolutely of the highest quality.
                Exacting care has gone into the prep work on each and every one of these.
                I am sure you will agree once you see them up close and personal.
                They are all lower Ordovician, approximately 500 million years old...yes, a half a billion years old!
              </p>
              <!--ancor-->
              <a name="shipping"></a>
              <!--ancor-->
              <hr style='height: 7px; background-color: rgb(78,63,33);'/>
              <p id='payment' class='size' align='center'>
                <strong>PAYMENT</strong>
              </p>
              <p class='remarks'>
                We accept PayPal and bank translation.
                Please contact us if you have any questions about payment.
              </p>
              <p id='shipping' class='size' align='center'>
                <strong>SH&amp;H TO WORLDWIDE:</strong>
              </p>
              <p class='remarks'>
                We need some time to pack the parcels, so we send the parcel within one week after you paid.
              </p>
              <p class='remarks'>
                We combine shipping of the items bought within one week.
                We calculate the total shipping price considering total weight of parcel, so discounts for total shipping price are possible.
                Please contact us if you have any questions about combine shipping.
              </p>
            </td>
          </tr>
          <tr>

            <!--see other items-->
            <td>
              <!--ancor-->
              <a name="other"></a>
              <!--ancor-->
              <hr style='height: 7px; background-color: rgb(78,63,33);'/>
              <p id='other' class='remarks' align='center'>You may be interested in our other listings on eBay:</p>
              <!--auctivia-->
              <!--ASW-->
              <!--version 1.0-->
              <table width='100%'  border='0' align='center' cellpadding='0' cellspacing='0'>
                <tr>
                  <td>
                    <script language='JavaScript' type='text/javascript'>
                      <xsl:comment>
                        <![CDATA[
                      function scrapeCat(){
                      var are = /.+\/category(\d+?)\//im; var ama = document.body.innerHTML.match(are); if (ama != null && ama.length == 2) { return ama[1]; } else { return '-1'; } }function passpara(){return '&id=1138098&itembgcolor=0xFFFFFF&bordercolor=0x000006&storewindowbgcolor=0xCEBF96&toptextcolor=0xFFFFFF&bottomtextcolor=0xFFFFFF&stripcolor=0x4E3F21&auctionclosemessagecolor=0x4E3F21&emptyboxmessagecolor=0x4E3F21&buttovercolor=0x4E3F21&buttoutcolor=0x4E3F21&searchtitlecolor=0xFFFFFF&searchbuttbgcolor=0xFFFFFF&searchbutttextcolor=0x4E3F21&searchbuttbordercolor=0xCEBF96&itemhighlightcolor=0xCEBF96&navbuttonactivecolor=0xCEBF96&navbuttonoutlinecolor=0xCEBF96&navbuttoninactivebgcolor=0xCEBF96&siteid=0&cat=' + scrapeCat() + '&baseurl='+escape(location.href.substring(0, location.href.lastIndexOf('/') + 1));
                      }]]>
                      </xsl:comment>
                    </script>

                    <script language='JavaScript' type='text/javascript'>
                      <xsl:comment>
                        <![CDATA[
                       
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
    
    ]]>
                      </xsl:comment>
                    </script>
                    <noscript>
                      <p class='remarks' align='center'>Please enable JavaScipt for view..</p>
                    </noscript>

                  </td>
                </tr>
              </table>
              <!--ASW-->
              <!--auctivia-->
            </td>
          </tr>
        </table>


      </body>
    </html>


  </xsl:template>

  <xsl:template match="SAMPLE" >

    <!--main table-->
    <table  border="0" width="945" align="center" >
      <!--row 1-->
      <tr>
        <!--cell left-->
        <td valign="top" >
          <!--(1) name and described cell-->

          <p class="caption_sample">
            <xsl:value-of select="NAME"/>
          </p>
          <!--Described field-->
          <p class="described">
            <xsl:value-of select="substring-before(substring-after(//SAMPLE/DESCR,'+'),'+')"/>
          </p>
        </td>
        <!--cell right-->
        <td>
          <!--Age field-->
          <p class="age">
            <xsl:value-of select="substring-before(substring-after(//SAMPLE/DESCR,'/'),'/')"/>
          </p>
        </td>
      </tr>
      <!--row 2 main table-->
      <tr>
        <td valign="top">
          <!--table of pictures of trilobites-->
          <table border="0">
            <xsl:apply-templates select="ROW" ></xsl:apply-templates>
          </table>
          <!--Barcode-->
          <p class="bartext" align="left">
            No: <xsl:value-of select="@bar"/>
          </p>
        </td>

        <td  align="center" valign="top">
          <!--horizont selector-->
          <xsl:choose>
            <xsl:when test="contains(substring-before(substring-after(//SAMPLE/DESCR,'/'),'/'), 'Asery')">
              <a href="{$root}Schema2008-november_2_big.gif" target="_blank">
                <img src="{$root}Schema2008-november_Asery.gif"  width="474"  border="0"></img>
              </a>
            </xsl:when>
            <xsl:when test="contains(substring-before(substring-after(//SAMPLE/DESCR,'/'),'/'), 'Kunda')">
              <a href="{$root}Schema2008-november_2_big.gif" target="_blank">
                <img src="{$root}Schema2008-november_Kunda.gif"  width="474"  border="0"></img>
              </a>
            </xsl:when>
            <xsl:when test="contains(substring-before(substring-after(//SAMPLE/DESCR,'/'),'/'), 'Lasnamagi')">
              <a href="{$root}Schema2008-november_2_big.gif" target="_blank">
                <img src="{$root}Schema2008-november_lasnamagi.gif"  width="474"  border="0"></img>
              </a>
            </xsl:when>
            <xsl:when test="contains(substring-before(substring-after(//SAMPLE/DESCR,'/'),'/'), 'Volkhov')">
              <a href="{$root}Schema2008-november_2_big.gif" target="_blank">
                <img src="{$root}Schema2008-november_volkhov.gif"  width="474"  border="0"></img>
              </a>
            </xsl:when>
            <xsl:when test="contains(substring-before(substring-after(//SAMPLE/DESCR,'/'),'/'), 'Uhaku')">
              <a href="{$root}Schema2008-november_2_big.gif" target="_blank">
                <img src="{$root}Schema2008-november_uhaku.gif"  width="474"  border="0"></img>
              </a>
            </xsl:when>
            <xsl:otherwise>
              <!--horisont not set = describeds fill-->
              <!--describeds-->
              <br/>
              <!--Described field-->
              <p class="described">
                <xsl:value-of select="substring-before(substring-after(//SAMPLE/DESCR,'+'),'+')"/>
              </p>
              <!--Remarks field-->
              <p class="remarks">
                <xsl:value-of select="substring-before(substring-after(//SAMPLE/DESCR,'#'),'#')"/>
              </p>
              <!--Add Text field-->
              <p class="addtext">
                <xsl:value-of select="substring-before(substring-after(//SAMPLE/DESCR,'$'),'$')"/>
              </p>

            </xsl:otherwise>
          </xsl:choose>

          <!--base = top="-value-21" left="value-167"-->
          <!--vid selector (arrow)-->
          <xsl:choose>
            <xsl:when test="contains(//SAMPLE/NAME, 'broeggeri')">
              <div class="arrow" style="top:-81px; left:-72px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'lepidurus')">
              <div class="arrow" style="top:-101px; left:-72px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'acuminatus lamanskii')">
              <div class="arrow" style="top:-126px; left:-72px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'acuminatus acuminatus')">
              <div class="arrow" style="top:-151px; left:-72px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'raniceps')">
              <div class="arrow" style="top:-173px; left:-72px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'striatus sarsi')">
              <div class="arrow" style="top:-209px; left:-72px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'striatus striatus')">
              <div class="arrow" style="top:-225px; left:-72px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'pachyophthalmus')">
              <div class="arrow" style="top:-280px; left:-72px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'minutus')">
              <div class="arrow" style="top:-222px; left:-138px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'minor')">
              <div class="arrow" style="top:-255px; left:-138px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'expansus gracilis')">
              <div class="arrow" style="top:-118px; left:71px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'expansus robustus')">
              <div class="arrow" style="top:-134px; left:71px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'expansus deltifrons')">
              <div class="arrow" style="top:-154px; left:71px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'knyrkoi')">
              <div class="arrow" style="top:-229px; left:71px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'sulevi')">
              <div class="arrow" style="top:-294px; left:71px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'ingrianus')">
              <div class="arrow" style="top:-309px; left:71px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'laevissimus')">
              <div class="arrow" style="top:-322px; left:71px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'heckeri')">
              <div class="arrow" style="top:-335px; left:71px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'laticaudatus')">
              <div class="arrow" style="top:-370px; left:71px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'uralicus')">
              <div class="arrow" style="top:-462px; left:71px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'latus')">
              <div class="arrow" style="top:-511px; left:38px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'plautini polyxenus')">
              <div class="arrow" style="top:-502px; left:86px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'plautini plautini')">
              <div class="arrow" style="top:-522px; left:84px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'bottnicus')">
              <div class="arrow" style="top:-581px; left:53px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'ornatus')">
              <div class="arrow" style="top:-583px; left:115px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'latisegmentatus')">
              <div class="arrow" style="top:-363px; left:-11px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'spinifer')">
              <div class="arrow" style="top:-443px; left:-11px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'kotlukovi kotlukovi')">
              <div class="arrow" style="top:-358px; left:-90px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'kotlukovi tumidus')">
              <div class="arrow" style="top:-387px; left:-90px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'punctatus')">
              <div class="arrow" style="top:-440px; left:-90px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'intermedius')">
              <div class="arrow" style="top:-456px; left:-90px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'kowalewskii')">
              <div class="arrow" style="top:-495px; left:-90px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'cornutus')">
              <div class="arrow" style="top:-430px; left:-154px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'holmi')">
              <div class="arrow" style="top:-506px; left:-154px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'devexsus')">
              <div class="arrow" style="top:-644px; left:-59px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'mjannili')">
              <div class="arrow" style="top:-625px; left:-59px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'delphinus')">
              <div class="arrow" style="top:-523px; left:-48px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>
            <xsl:when test="contains(//SAMPLE/NAME, 'onchometopus')">
              <div class="arrow" style="top:-88px; left:45px;">
                <img src="{$root}/arrow.gif"></img>
              </div>
            </xsl:when>



            <xsl:otherwise>
              <p class="age">The species has distribution on all horizon</p>
            </xsl:otherwise>
          </xsl:choose>






        </td>
      </tr>
    </table>

    <!--size,remarks,add text-->
    <!--Size-->
    <!--NEW ancor-->
    <a name="size"></a>
    <!--NEW-->
    <p id="size" class="size" align="center">
      <strong>
        Size: <xsl:value-of select="SIZE"/>
      </strong>
    </p>
    <!--Remarks field-->
    <p class="remarks" align="center">
      <xsl:value-of select="substring-before(substring-after(//SAMPLE/DESCR,'#'),'#')"/>
    </p>
    <!--Add Text field-->
    <p class="addtext" align="center">
      <xsl:value-of select="substring-before(substring-after(//SAMPLE/DESCR,'$'),'$')"/>
    </p>
    <!--found in-->
    <xsl:choose>
      <xsl:when test="contains(substring-before(substring-after(//SAMPLE/DESCR,'*'),'*'), 'Volkhov')">
        <p class="locality" align="center">
          <xsl:value-of select="substring-before(substring-after(//SAMPLE/DESCR,'*'),'*')"/>
        </p>
        <p class="locality" align="center">
          <a href="http://www.panoramio.com/map/#lt=59.926131&amp;ln=32.340942&amp;z=4&amp;k=2&amp;tab=2" target="_blank">
            <img src="{$root}outcrop_Volkhov.gif"  width="474"  border="0" ></img>
          </a>
        </p>
      </xsl:when>
      <xsl:when test="contains(substring-before(substring-after(//SAMPLE/DESCR,'*'),'*'), 'Vilpovicy')">
        <p class="locality" align="center">
          <xsl:value-of select="substring-before(substring-after(//SAMPLE/DESCR,'*'),'*')"/>
        </p>
        <p class="locality" align="center">
          <img src="{$root}outcrop_Vilpovicy.gif"  width="474"  border="0" ></img>
        </p>
      </xsl:when>
      <xsl:when test="contains(substring-before(substring-after(//SAMPLE/DESCR,'*'),'*'), 'Lawa')">
        <p class="locality" align="center">
          <xsl:value-of select="substring-before(substring-after(//SAMPLE/DESCR,'*'),'*')"/>
        </p>
        <p class="locality" align="center">
          <img src="{$root}outcrop_Lava.gif"  width="474"  border="0" ></img>
        </p>
      </xsl:when>
      <xsl:otherwise>
        <p class="locality" align="center">
          <xsl:value-of select="substring-before(substring-after(//SAMPLE/DESCR,'*'),'*')"/>
        </p>
      </xsl:otherwise>
    </xsl:choose>
    <!--</body>-->

    <!--</html>-->

  </xsl:template>
  <xsl:template match="ROW">
    <tr>
      <xsl:for-each select="IMAGE">
        <td width="228" height="171" align="center">
          <a href="{$root}{$image-dir}/{//SAMPLE/@bar}/{$hiresimage-dir}/{@src}" target="_blank">
            <img src="{$root}{$image-dir}/{//SAMPLE/@bar}/{$lowimage-dir}/{@src}"  width="228" height="171" border="0">
            </img>
          </a>
        </td>
      </xsl:for-each>

    </tr>
  </xsl:template>

</xsl:stylesheet>