<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" encoding="windows-1251" indent="yes"/>
  <!--�������� ����  -->
  <xsl:variable name="root"></xsl:variable>
  
  <xsl:template match="/">
     <!--main html document region-->
      <html>
        <style type="text/css">
          /* ���� �������� */
          .body_color {
          background-color:#cebf96;
          font-family: "Bodoni MT";
          line-height: normal;
          font-size:small;
          color: rgb(78,63,33);
          }


          /*����������� ��������*/
          .hr_sample{
          height: 5px;
          background-color: rgb(78,63,33);
          }

          
          /*����������� �����-����*/
          .hr_catalog{
          height: 7px;
          background-color: rgb(78,63,33);
          }
          
          
          /*��������� ��������*/
          .caption_catalog {
          background-color: #C0C0C0;
          font-size: x-large;
          font-weight: bold;
          text-align:center;
          vertical-align:top;
          }

          
          /*�������� ���� ��������*/
          .div_main
          {
          display:block;
          /*position:absolute;*/
          left: 5%;
          top: 0px;
          height: 100%;
          }

          /*����� ������� */
          .NUMBER
          {
          font-size: x-small;
          font-weight: lighter;
          }
            /*alt ��� */
          .alt
          {
          font-size: medium;
          font-weight: bold;
          }
          
          /*��������� ���� @position=title*/
          .div_title
          {
          /*background-color: #C0C0C0;*/
          padding-left: 140px;
          font-size: medium;
          /*font-weight: bold;*/
          /*border : 1px inset #000000;*/
          }

          /*������� ������ ���� @position='upperright'*/
          .div_upperright
          {
          font-size: medium;
          }


          /*������� ����� ���� @position='upperleft'*/
          .div_upperleft
          {
          font-size: medium;
          }
          
          /*������ ����*/
          .div_down
          {
          font-size: medium;
          }

          /*���� ��������*/
          .div_image
          {
          width: 100%;
          }

          /*�������� �������*/
          .sample_image
          {
          height : 171px;
          border : medium double #000000;
          }
          
          /*�������� ����*/
          .summary
          {
          font-size: x-large;
          font-weight: bold;
          }
        </style>
        <!--
        <link rel="stylesheet" type="text/css" href="CatalogCSS.css" media="all"></link>-->
        <head>
         
          <META http-equiv="Content-Type" content="text/html; charset=windows-1251"/>
           
          <!--�������� ��������-->
          <title>
            <xsl:value-of select="//CATALOG/@name"/>
          </title>
          <!--�������-->
          <!--���� ���-->
        </head>
        <body class="body_color" >
          <!--����� ����========================================================== -->
          <!--������� left ������ ������� ����� �����  -->
          <div class="div_main">
            <!--������� �����-->
            <div class="div_caption">
              <!--������� ��������-->
              <p class="caption_catalog">
                <xsl:value-of select="//CATALOG/@title"/>
                <xsl:text>&#160;&#160;</xsl:text>
                <small> <xsl:value-of select="//CATALOG/@date"/> </small>
              </p>
            </div>
            <!--������ ����� �������======================================================== -->
            <xsl:apply-templates select="//SAMPLE">
              <!--���������� �� ��������-->
              <xsl:sort select="./DATA/ELEMENT[@name='NAME']/text()" data-type="text" />
            </xsl:apply-templates>
            <!--����� ����� �������============================================================ -->
            
            <!--���� ������ ��� ��������============================-->
           <hr class="hr_catalog"  />
           <div class="summary">
            <!--��������� ����������--> 
             <!--������ � ������ ������-->   
             <xsl:variable name="subthree_price">
                  <xsl:for-each select="//ELEMENT[@name='PRICE']/text()">
                    <xsl:element name="item">
                     <xsl:value-of select="number(translate(substring(.,2),',',''))"/>
                    </xsl:element>
                  </xsl:for-each>
                </xsl:variable>
             <xsl:variable name="retail_sum" select="sum(msxsl:node-set($subthree_price)/item)"></xsl:variable>
             
             <!--������ �� ���������� ������-->
             <xsl:variable name="subthree_discount_price">
               <xsl:for-each select="//ELEMENT[@name='YOUPRICE']/text()">
                 <xsl:element name="item">
                   <xsl:value-of select="number(translate(substring(.,2),',',''))"/>
                 </xsl:element>
               </xsl:for-each>
             </xsl:variable>
             <xsl:variable name="discount_sum" select="sum(msxsl:node-set($subthree_discount_price)/item)"/>

             <!--������ � �����-->
             <xsl:variable name="subthree_weight">
               <xsl:for-each select="//ELEMENT[@name='WEIGHT']/text()">
                 <xsl:element name="item">
                   <xsl:value-of select="number(translate(translate(.,'kg',''),',',''))"/>
                 </xsl:element>
               </xsl:for-each>
             </xsl:variable>
             <xsl:variable name="weight_sum" select="sum(msxsl:node-set($subthree_weight)/item)"/>
             
             <!--������ ��������-->
             <xsl:variable name="subthree_name">
               <xsl:for-each select="//SAMPLE">
                 <xsl:element name="item">
                   <xsl:value-of select="@bar"/>
                 </xsl:element>
               </xsl:for-each>
             </xsl:variable>
             <xsl:variable name="name_count" select="count(msxsl:node-set($subthree_name)/item)"/>
             
             <!--���� ������ (������� �� �������� price)-->
             <xsl:variable name="currency_char" select="substring-before(//ELEMENT[@name='PRICE']/text(),1)"/>
             
             <!--�����============>>>>>>-->
             <xsl:choose>
               <xsl:when test="$name_count>0">
             <p>
               <pre>
                 <xsl:text>Qty:&#009;&#009;&#009;</xsl:text>
               <!--���-��-->
               <xsl:value-of select="$name_count"/>
               <xsl:text>&#160;pcs</xsl:text>
               </pre>
             </p>
               </xsl:when>
             </xsl:choose>
                 
      <!--����� ����� ���� 0 �� ������������-->
      <xsl:choose>
      <xsl:when test="$retail_sum>0">       

                <p>
               <pre>
               <xsl:text>total:&#009;</xsl:text>
                <!--���� ������-->
                <xsl:value-of select="$currency_char"/>
                <!--����� �� ������ �����-->
                <xsl:value-of select="format-number($retail_sum,'0.00')"/>
                </pre> 
                </p>
      </xsl:when>
     </xsl:choose>
             
               <!--����� ���-->
             <xsl:choose>
               <xsl:when test="$weight_sum>0">

                 <p>
               <pre style="font-size: small;">
                 <xsl:text>Total net weight:&#009;</xsl:text>
                 <xsl:value-of select="format-number(($weight_sum),'0.0')"/>
                 <xsl:text>&#160;kg</xsl:text>
               </pre>
             </p>
               </xsl:when>
             </xsl:choose>
             <!--����� ������ ���� 0 �� ������������-->
             <xsl:choose>
               <xsl:when test="$discount_sum>0">
                  <p>
               <pre>
               <xsl:text>Your total:&#009;</xsl:text>
               <!--���� ������-->
               <xsl:value-of select="$currency_char"/>
               <!--����� �� ����� �� �������-->
               <xsl:value-of select="format-number($discount_sum,'0.00')"/>
               </pre>
             </p>
                   <!--you save-->
             <hr />
             <p>
               <pre style="font-size: small;"> <xsl:text>You save:&#009;&#009;</xsl:text>
               <!--���� ������-->
               <xsl:value-of select="$currency_char"/>
               <!--������� � �����-->
               <xsl:value-of select="format-number(($retail_sum - $discount_sum),'0.00')"/>
               </pre>
             </p>
               </xsl:when>
             </xsl:choose>
             <hr />
          </div>
            
          </div>
          <!--����� ������ �����-->

        </body>

          </html>
</xsl:template>
  
  <!--====================================-->
  <!--������ ��� �������-->
  <xsl:template match="SAMPLE">
    <!--��������� �����������-->
    <!--ID ������� ������ ������� ���������-->
    <hr id="{@bar}"  class="hr_sample" />
    <xsl:apply-templates select="./DATA">
      <xsl:with-param name="number" select="@bar"></xsl:with-param>
    </xsl:apply-templates>
    <!--�������� �����������
    <hr class="hr_sample" /> -->
  </xsl:template>
  
  <!--=============================================-->
  <!--������ ����� ������-->
  <xsl:template match="DATA">
    <xsl:param name="number"></xsl:param>
    <table style="width:100%;">
      <tr>
        <td id="title_block" style="width: 50%" valign="top">
          <!--������� ��������� ����-->
          <div class="div_title">
            <!--������� �����-->
            <p class="NUMBER">
              <xsl:value-of select="//CATALOG/@numberstring"/>
              <xsl:text>:&#009;</xsl:text>
              <xsl:value-of select="$number"/>
            </p>
            <!--�������� ���� ������-->
            <xsl:apply-templates select="ELEMENT[@position='title']">
              <xsl:sort select="@order"/>
            </xsl:apply-templates>
          </div>

          <br />

          <!--������� ������� ����� ����-->
          <div class="div_upperleft">
            <!--�������� ���� ������-->
            <xsl:apply-templates select="ELEMENT[@position='upperleft']">
              <xsl:sort select="@order"/>
            </xsl:apply-templates>
          </div>
        </td>
        <td id="upperleft_block" valign="top">
          <!--������� ������� ������ ����-->
          <div class="div_upperright">
            <!--�������� ���� ������-->
            <xsl:apply-templates select="ELEMENT[@position='upperright']">
              <xsl:sort select="@order"/>
            </xsl:apply-templates>
          </div>
        </td>
      </tr>
      <tr>
        <td id="image_block" colspan="2">
          <!--�������� ��������-->
          <!--���� ����������� �������-->
          <br/>
          <div class="div_image">
            <xsl:apply-templates select="../IMAGES/IMAGE"></xsl:apply-templates>
          </div>
          <br/>
        </td>
      </tr>
      <tr>
        <td id="down_block" colspan="2">
          <!--������� ������ ���� (����� ��������)-->
          <div class="div_down">
            <!--�������� ���� ������-->
            <xsl:apply-templates select="ELEMENT[@position='down']">
              <xsl:sort select="@order"/>
            </xsl:apply-templates>
          </div>
        </td>
      </tr>
    </table>

    
  </xsl:template>
 
  <!--==� ������ ����� ����������� �� @position � @order=============================================-->
  <!--������ �������� �����-->
  <xsl:template match="ELEMENT">
    <!--����-->
    
    <p>
      <font class="alt"> <xsl:value-of select="@alt"/>
        <xsl:text>:&#009;</xsl:text></font>
         <xsl:value-of select="text()"/>
       <xsl:apply-templates select="ENVIRONMENT">
         <xsl:with-param name="link" select="text()[2]">
         </xsl:with-param>
       </xsl:apply-templates>
      
    </p>
    
    
  </xsl:template>
  
  
  <!--==============================================-->
  <!--������ ���������-->
  <xsl:template match="ENVIRONMENT">
    <xsl:param name="link"></xsl:param>
    <a href="{@href}">
      <xsl:value-of select="$link"/>
    </a>
  </xsl:template>
  
  <!--==============================================-->
  <!--������ ��������-->
  <xsl:template match="IMAGE">


    <!-- <a href="{../../@bar}/{@src}" target="_blank" title="Click to enlarge">
    <img class="sample_image" alt="{@src}"  src="{../../@bar}/{@src}"  />
    </a> -->
    <a href="{@src}" target="_blank" title="Click to enlarge">
      <img class="sample_image" alt="{@src}"  src="{@src}"  />
    </a>
  </xsl:template>
  
  
</xsl:stylesheet>
