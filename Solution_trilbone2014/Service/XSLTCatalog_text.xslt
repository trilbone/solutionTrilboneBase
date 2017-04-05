<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                xmlns:trilbone="http://trilbone.com/"
>
    <xsl:output method="text" indent="yes" encoding="windows-1251" omit-xml-declaration="no"/>
  <msxsl:script language="JScript" implements-prefix="trilbone">
    /*добавляет заданное кол-во пробелов в зависимости от названия*/
    function getNormalizeString(instring, name) {
    var outstring : String = instring;
    var num : Number = outstring.length;
    var sps : Number;

    /*расстояние между столбцами*/
    var step = 3;

    switch (name) {

    case "NUMBER":
    sps = 13-num + step;
    return (outstring + getSpaceStr(sps));
    break;
    case "NAME":
    sps = 50 - num + step;
    return (outstring + getSpaceStr(sps));
    break;
    case "FOSSILSIZE":
    sps = 16 - num + step;
    return (outstring + getSpaceStr(sps));
    break;

    case "PRICE":
    sps = 9 - num;
    outstring = getSpaceStr(sps) + outstring;
    return (outstring + getSpaceStr(step+step));
    break;

    case "DISCOUNT":
    sps = 3 - num + step+step;
    return (outstring + getSpaceStr(sps));
    break;

    case "YOUPRICE":
    sps = 9 - num;
    outstring = getSpaceStr(sps) + outstring;
    return (outstring + getSpaceStr(step));
    break;

    default:
    return outstring;
    }
    }
    /*пробельная функция*/
    function getSpaceStr(num) {
    var str : String;
    for (var i = 0; !(i > num); i++) {
    str = str + " ";
    }
    return str;
    }
  </msxsl:script>
  
  
  <xsl:template match="/">
    
    <!--Название каталога-->
    <xsl:text>#</xsl:text>
    <xsl:value-of select="//CATALOG/@name"/>
    <xsl:text>&#10;&#13;</xsl:text>
    <xsl:value-of select="//CATALOG/@title"/>
    <xsl:text>&#10;&#13;</xsl:text>

    <xsl:text>Date: </xsl:text>
    <xsl:value-of select="//CATALOG/@date"/>
    <xsl:text>&#10;&#13;</xsl:text>

    <xsl:text>=============================================================================================================</xsl:text>
    <xsl:text>&#13;</xsl:text>
    <!--заголовки-->
    <xsl:value-of select="trilbone:getNormalizeString('Number','NUMBER')"/>
    <xsl:value-of select="trilbone:getNormalizeString('Name','NAME')"/>
    <xsl:value-of select="trilbone:getNormalizeString('Size','FOSSILSIZE')"/>
    <xsl:value-of select="trilbone:getNormalizeString('Price','PRICE')"/>
    <xsl:value-of select="trilbone:getNormalizeString('Discount','DISCOUNT')"/>
    <xsl:value-of select="trilbone:getNormalizeString('Your price','YOUPRICE')"/>

    <xsl:text>&#10;&#13;</xsl:text>

    <!--Начало блока образца======================================================== -->
    <xsl:apply-templates select="//SAMPLE">
      <!--сортировка по номерам-->
      <xsl:sort select="./DATA/ELEMENT[@name='NUMBER']/text()" data-type="number" />
    </xsl:apply-templates>
    <!--Конец блока образца============================================================ -->
    <xsl:text>==============================================================================================================</xsl:text>
    <xsl:text>&#13;</xsl:text>
    <!--блок итогов для каталога-->
            <!--вычисляем переменные-->
    <!--дерево с ретайл ценами-->
    <xsl:variable name="subthree_price">
      <xsl:for-each select="//ELEMENT[@name='PRICE']/text()">
        <xsl:element name="item">
          <xsl:value-of select="number(translate(substring(.,2),',',''))"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:variable>
    <xsl:variable name="retail_sum" select="sum(msxsl:node-set($subthree_price)/item)"></xsl:variable>

    <!--дерево со скидочными ценами-->
    <xsl:variable name="subthree_discount_price">
      <xsl:for-each select="//ELEMENT[@name='YOUPRICE']/text()">
        <xsl:element name="item">
          <xsl:value-of select="number(translate(substring(.,2),',',''))"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:variable>
    <xsl:variable name="discount_sum" select="sum(msxsl:node-set($subthree_discount_price)/item)"/>

    <!--дерево с весом-->
    <xsl:variable name="subthree_weight">
      <xsl:for-each select="//ELEMENT[@name='WEIGHT']/text()">
        <xsl:element name="item">
          <xsl:value-of select="number(translate(translate(.,'kg',''),',',''))"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:variable>
    <xsl:variable name="weight_sum" select="sum(msxsl:node-set($subthree_weight)/item)"/>

    <!--дерево названий-->
    <xsl:variable name="subthree_name">
      <xsl:for-each select="//ELEMENT[@name='NAME']/text()">
        <xsl:element name="item">
          <xsl:value-of select="number(translate(translate(.,'kg',''),',',''))"/>
        </xsl:element>
      </xsl:for-each>
    </xsl:variable>
    <xsl:variable name="name_count" select="count(msxsl:node-set($subthree_name)/item)"/>

            <!--знак валюты (берется из атрибута price)-->
            <xsl:variable name="currency_char" select="substring(//ELEMENT[@name='PRICE']/text(),1,1)"/>

    <!--кол-во-->
    <xsl:text>Qty:&#160;</xsl:text>
    <xsl:value-of select="$name_count"/>
    <xsl:text>&#160;pcs</xsl:text>
    <xsl:value-of select="trilbone:getSpaceStr(13+3+30)"/>



    <xsl:text>total:&#160;</xsl:text>
                <!--знак валюты-->
                <xsl:value-of select="$currency_char"/>
                <!--сумма по ретайл ценам-->
                <xsl:value-of select="format-number($retail_sum,'0.00')"/>
    <xsl:value-of select="trilbone:getSpaceStr(3+3)"/>

    <xsl:text>Your total:&#160;</xsl:text>
                <!--знак валюты-->
                <xsl:value-of select="$currency_char"/>
                <!--сумма по ценам со скидкой-->
                <xsl:value-of select="format-number($discount_sum,'0.00')"/>
    <xsl:text>&#10;&#13;</xsl:text>
     
    <xsl:text>Total net weight:&#160;</xsl:text>
                <xsl:value-of select="format-number(($weight_sum * 0.001),'0.0')"/>
                <xsl:text>&#160;kg</xsl:text>
    <xsl:value-of select="trilbone:getSpaceStr(13+3+30+3+12+3)"/>

    <xsl:text>(You save:&#160;</xsl:text>
                <!--знак валюты-->
                <xsl:value-of select="$currency_char"/>
                <!--разница в ценах-->
                <xsl:value-of select="format-number(($retail_sum - $discount_sum),'0.00')"/>
    <xsl:text>)</xsl:text>
    <xsl:text>&#10;&#13;</xsl:text>
    <xsl:text>Best Regards</xsl:text>
    <xsl:text>&#13;</xsl:text>
    <xsl:text>Evgeny</xsl:text>


  </xsl:template>

  <!--====================================-->
  <!--шаблон для образца-->
  <xsl:template match="SAMPLE">
    <xsl:apply-templates select="./DATA"></xsl:apply-templates>
    <xsl:text>&#10;&#13;</xsl:text>
  </xsl:template>
  <!--=============================================-->
  <!--шаблон блока данных-->
  <xsl:template match="DATA">
    <!--getNormalizeString(instring, name)-->
    <!--вставить поля данных-->

    <xsl:value-of select="trilbone:getNormalizeString(string(ELEMENT[@position='title'][@name='NUMBER']/text()),'NUMBER')"/>
    <xsl:value-of select="trilbone:getNormalizeString(string(ELEMENT[@position='title'][@name='NAME']/text()),'NAME')"/>
    <xsl:value-of select="trilbone:getNormalizeString(string(ELEMENT[@position='upperleft'][@name='FOSSILSIZE'][1]/text()),'FOSSILSIZE')"/>
    <xsl:value-of select="trilbone:getNormalizeString(string(ELEMENT[@position='down'][@name='PRICE']/text()),'PRICE')"/>
    <xsl:value-of select="trilbone:getNormalizeString(string(ELEMENT[@position='down'][@name='DISCOUNT']/text()),'DISCOUNT')"/>
    <xsl:value-of select="trilbone:getNormalizeString(string(ELEMENT[@position='down'][@name='YOUPRICE']/text()),'YOUPRICE')"/>


    <!--
    <xsl:value-of select="ELEMENT[@position='title'][@name='NUMBER']/text()"/>
    <xsl:text>&#009;</xsl:text>
    
    <xsl:value-of select="normalize-space(ELEMENT[@position='title'][@name='NAME']/text())"/>
    <xsl:text>&#009;&#009;&#009;&#009;</xsl:text>

    <xsl:value-of select="ELEMENT[@position='upperleft'][@name='FOSSILSIZE'][1]/text()"/>
    <xsl:text>&#009;&#009;</xsl:text>

    <xsl:value-of select="ELEMENT[@position='down'][@name='PRICE']/text()"/>
    <xsl:text>&#009;&#009;</xsl:text>

    <xsl:value-of select="ELEMENT[@position='down'][@name='DISCOUNT']/text()"/>
    <xsl:text>&#009;&#009;</xsl:text>

    <xsl:value-of select="ELEMENT[@position='down'][@name='YOUPRICE']/text()"/>
    <xsl:text>&#009;</xsl:text>
     -->
  </xsl:template>



</xsl:stylesheet>
