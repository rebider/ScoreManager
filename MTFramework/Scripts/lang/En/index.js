var weblang = {
    //公用
    'bank_transfer1': 'Bank Transfer ',//银行汇款
    'money_transfer': 'Money Transfer',//Exp标题
    'Exp': '',//Exp标题
    'Password1': 'New Pwd',
    'levelAgent': 'Level IB ',//'上级代理号',
    'IBNum': 'IB ',// '代理号',
    'confirm_password1': 'Confirm Pwd',
    'status_failed': 'Failed', //失败
    'status_success': 'Success', //成功
    'status_check': '审核中',
    'username_cn': 'Chinese Name', //中文名
    'username': 'English Name',//英文名
    'success': 'Success', //保存成功
    'error': 'Error', //保存失败
    'my_account': 'My Account', //我的账户
    'my_profile': 'My Profile', //我的资料
    'golden': 'Deposit', //入金
    'withdraw': 'Withdraw', //出金
    'agency': 'Agent', //代理
    'log_off': 'Log off', //退出登录
    'leverage': 'Leverage', //杠杆
    'type': 'Type', //类型
    'wallet': 'Vault', //钱包
    'my_Wallet': 'Vault',
    'trading_account': 'Trading account', //交易账户
    'trading_accountname': 'Current Trading Account Name',//修改交易账户名（现账户名）
    'trading_accountNewname': 'New Trading Account Name',//修改交易账户名（新账户名）
    'phone': 'Phone', //电话
    'email': 'Email', //邮箱
    'emai': 'Email', //邮箱
    'province': 'Province',
    'city': 'City',
    'area1': 'District',
    'westfield_wallet': 'Vault', //Westfield 钱包
    'currency_type': 'Currency type', //货币种类
    'manage_wallet': 'Manage My Vault', //管理我的 Westfield 钱包
    'transfer_accounts': 'Transfer account', //转出账户
    'into_account': 'Into account <span style=\'color:red\'>(email)</span>', //转入账户
    'sum': 'Amount', //金额
    'c_account': 'If the account is transferred into the account can only be turned into a trading account, but if the account is turned out to be a trading account can only be transferred to the account Vault', //转出账户如果是钱包 则转入账户只能是交易账户,如果转出账户是交易账户 则传入账户只能是钱包
    'records': 'Money Management', //资金管理记录
    'date_time': 'Date/time', //日期/时间
    'way': 'Method', //方式
    'source_account': 'The source account', //源账户
    'target_account': 'The target account', //目标账户
    'money': 'Money', //资金
    'converted': 'Converted', //内转
    'rotation': 'Rotation', //自转
    'capital': 'Capital',//外转
    'Rotation_remarks': '*: This method is limited to the transfer between the Vault and the account, not used for mutual transfer between accounts and accounts',//自转备注
    'Inside_notes': '*: This approach is limited to commissions issued by the agent for customer using, the amount will be frozen, and waiting for review. <br/> If approved by the audit, the amount will be frozen into the filled user Vault. If the audit is not passed, the amount will be returned to the current user freeze Vault.',//内转备注
    'remark': 'Remark',//备注
    'remark_crm': 'remark of crm',//客户crm显示备注
    'remark_mt4': 'remark of mt4',//客户mt4显示备注
    'commission': 'Commission', //佣金
    'net_silver': 'Net silver', //网银
    'system': 'System', //系统
    'current_balance': 'Current balance', //现余额
    'convert': 'Converted Into RMB', //转换金额
    'convert1': 'Converted Into RMB(￥)', //转换金额
    'display_credit': 'Display credit', //显示余额
    'choose': 'Choose', //选择
    'important_items': 'Important items', //重要事项
    'state': 'State', //状态
    'volume': 'Volume', //成交量
    'operate': 'Operation', //操作
    'save': 'save', //保存
    'close': 'close', //关闭
    'select': 'Please Select', //请选择
    'return': 'back',
    'total': 'Total', //共有
    'record': 'Records', //条
    'perpage': 'Per Page',
    'update_info': 'update information', //修改 用户信息
    'chinese': 'Chinese', //中文
    'english': 'English', //英文
    'nodata': 'No Datas',
    'man': 'Man', //男
    'woman': 'Woman', //女
    'birthday': 'Birthday', //出生日期

    'Accountname': 'Account name:', //帐户名  
    'logemail': 'LoginName',
    'Login': 'Login',//帐号  
    'User_Auth': 'User Authentification',//用户认证
    'detail': 'Detail',//下级详情
    'date': 'Date',
    'your_email': 'Your Email',//您的邮箱
    'd_password': 'Login password',//登录密码
    'sureapply':'Sure Apply',
    

    //--------------------------------------------//
    //注册界面开始
    'r_customer_registration': 'Customer registration',//'客户注册专区',
    'r_personal_information': 'According to the regulatory requirements of <span style="color:#f02a4a">FCA</span> and <span style="color:#f02a4a">FSP</span>，you need to fill in the KYC registration questionnaire <span style="color:#f02a4a">information truthfully</span>, otherwise the progress of your account application will <span style="color:#f02a4a">be delayed</span>.Please note <span style="color:#f02a4a">* is required</span>',// '根据FCA及FSP的合规监管要求，需要您如实填写KYC注册问卷信息，否则将会造成您的账户申请审核进度被延迟。',
    'r_regulator': 'Please select a regulator', // '请选择监管机构',
    'r_england_FSA': 'England FCA', // '英国FCA',
    'r_perInfo': 'Personal Data',
    'r_sex': '<span style=\'color:red;\'>* </span>Gender',
    'r_username_cn': '<span style=\'color:red;\'>* </span>Chinese Name',//中文名',
    'r_username': '<span style=\'color:red;\'>* </span>English Name',//英文名/拼音姓名',
    'r_zip': '<span style=\'color:red;\'>* </span>Zip',//邮编
    'r_address': '<span style=\'color:red;\'>* </span>Address',//地址',
    'r_phone': '<span style=\'color:red;\'>* </span>Phone',//手机号码',
    'r_email': '<span style=\'color:red;\'>* </span>Email',//邮箱',
    'r_emailinfo': '<span style=\'color:red;\'>（Be sure to fill in your own personal email）</span>',//请务必填写您自己的个人邮箱
    'r_confirmemail': '<span style=\'color:red;\'>* </span>Email confirmation',
    'r_ibcode': 'IB CODE',//'经纪人代码',
    'r_password': '<span style=\'color:red;\'>* </span>password',//密码
    'r_confirmpassword': '<span style=\'color:red;\'>* </span>Confirm password',//确认密码
    'r_noteInfo': '',// '(请注意 * 为必填项)',
    'r_country': '<span style=\'color:red;\'>* </span>Country of Residence',
    'Area': 'Area',
    //'N.z.': 'N.z.FSP',//新西兰FAC
    'Nz': 'N.z. FSP', //新西兰FSP
    'sex': 'Gender', //性别
    'country': 'Country', //居住国家/地区
    //注册界面结束
    //--------------------------------------------//




    //注册
    'perInfo': 'Personal Information',
  
    'ibcode': 'IB CODE',
    'typecode': 'TYPE CODE',
    'c_UserType': 'UserType',
    'ChangePwd': "Change Password",//修改密码
    'Zip': 'Zip',
    'Area':'Area',
    //'N.z.': 'N.z.FSP',//新西兰FAC
    'Nz': 'N.z. FSP', //新西兰FSP
    'sex': 'Gender', //性别
    'country': 'Country', //居住国家/地区
    'surnames': 'Surname', //姓氏
    'LoginCenter': 'Customer Login Center',//登录中心
    'IBLoginCenter': 'IB Login Center',//代理登录中心
    'email_confirmation': 'Email confirmation', //邮箱确认
    'introducing_broker': 'Introducing broker (IB) code', //介绍经纪人（IB）代码
    'write': 'If the customer to the agency to open an account, this code will be automatically generate.If it is not empty, you can also manually fill', //如果客户以代理链接开户，此代码要自动生成，如果不是可以空，也可手动填写
    'c_password': 'Customer background password', //客户后台密码
    'keep': 'Customer background ID will be your e-mail address, so please save this password. And you need to open a transaction account through the customer background', //客户后台ID将会是您填写的邮箱地址，请保存好此密码，您需要通过客户后台开通交易账户！
    'passwor': 'Pwd', //密码
    'Password': 'password', //密码
    'confirm_password': 'Confirm password', //确认密码
    'asd': 'PIN', //验证码
    'account_no': 'Do you have an account?',
    'go_register': 'If not ,please register now.',
    'NextAutoLogin': 'Next Auto Login', //下次自动登录
    'Home': 'Home', //返回主页
    'Forgetpassword': 'Forget password?',//忘记密码
    'Signin': 'Login',//登录
    'register':'register',//注册
    'open_account': 'Apply for opening an account',//申请开户
    'rlogin_to':'Return to login',//返回登录
    //注册成功后的反馈页面
    'info': 'Your application has been successfully sent，then we will send feedback information to your personal email, please check.If you have any questions, please send email to... The mailbox in SystemParam Settings',//您的申请已经成功发送，我们将反馈的信息发送至您个人电子邮箱，请查收如有疑问请发送邮件至。。。。此处邮箱在SystemParam里面设置
    //我的账户

    'money_management': 'Money Management',//管理资金
    'account': 'Account',//账户
    'myaccount': 'My Account',
    
    'free_margin': 'Useable margin',//免费保证金
    'account_balance': 'account balance',//账户余额
    'submit_application': 'submit application',//提交申请

    'MT4_Status': 'MT4 Account application status :',//MT4账户申请状态

   
    'operation': 'Discrepancy gold operation',//出入金操作
    'MT4_account': 'Open account with the MT4 same name',//开设MT4同名账户
    'into': 'Into',//转入
    'roll_out': 'roll out',//转出
    'Designatedmailbox': 'appoint mail',

    'apply_state': 'Leverage Applying Status :',

    'watting_apply': 'Watting Check',
    'had_passed': 'Pass',
    'had_failed': 'Failed',
    'equity': 'Equity',
    'profit': 'Profit',
    'sure_apply':'SureApply',
    'account_GroupName':'Group',

    'prompt': 'Prompt',//提示
    'confirm_account': 'Are you sure you want to reset the MT4 transaction account password? After determination, the new password will be sent to your account mailbox, please check.',//您确定重置该MT4交易账户密码？确定之后，新密码发送至您账户邮箱中，请注意查收。
    'reset': 'Reset password',//重置MT4密码
    'modify': 'Modify the lever',//修改杠杆
    'modifyname': 'Modify the Account Name',//修改Mt4名称
    'confirm': 'Confirm',//确定
    'cancel': 'Cancel',//取消
    'leveragelist': 'Leverage List',//可选杠杆
    'normal': 'Normal',//正常
    'lock': 'Lock',//锁定
    'applying': 'Applying',//申请中
    'real_account': 'RealAccount',//真实账户
    'typeone': 'StandardAccount',//'类型一',
    'typetwo': 'type two',//类型二
    'typethree': 'type three',//类型三
    'select_type': 'Please Select Account Type',//请选择类型
    'saving': 'Saving...',
    'getmoneyfaild': 'Failed to get the Vault balance',
    'reset_confirm': 'Are you sure to rest your login password? ',
    'tip': 'After confirming, change the password link to send to your mailbox, please pay attention to check',
    'tip1': 'After determining, use the new password to login to the client',
    'tip_1':'Tip',
    'resetting': 'Resetting...',
    'confirm_change': 'Are you confirm to change?',
    'noverify': 'Your account has not been certified and you cannot create a transaction account for the time being    ',
　　'iknow': 'OK',
   'goverify': 'go verify',
    'seeverify': 'see verify',
    'failedverify': 'Account activation failed and transaction account could not be created',
    'verifying': 'For activation, you cannot create a trading account for the time being, please be patient.....',
    'takeall': 'Transfer All',
//开设MT4交易账户
'creat_账户': 'Create MT4 account',//创建MT4账户
'account_type': 'Account type',//账户类型  
'currency': 'Currency',//货币
'trade_accounts': 'Create the MT4 trading accounts',//创建MT4交易账户
'mt4account': 'MT4 Account',
//管理资金
'surepay': 'Transfer Confirmation',
    'wallet_balance': 'Vault',
'account_select': 'Please Select Source/Target Account',//请选择转入转出账户
'write_money': 'Please fill in the transfer amount',//请填写转账金额
'transfer': 'Transfering',//转账中
'morethanzero':'Must be more than zero',

    
    'reset1':'Retrieve the password',// '找回密码',
    'agency1': 'Proxy User',//'代理用户',
    //我的资料
    'agentLevel': 'Proxy level ',
    'agentKinds': 'Proxy type ',
    'rebate_Type':'Rebate type ',//'返佣类型',
'per_data': 'Personal Data',//个人信息
'user_info': 'User Information',//用户信息
    'my_wllet': 'My Vault',//我的钱包
'bank_card': 'Bank Card',//银行卡
'nationality': 'Nationality',//国籍
'language': 'Language',//语言
'address': 'Address',//地址
    'authentication': 'Activate',//认证方式
 'cus_trun': 'Internal Tranfer',
 'user_turn': 'Override Issued',
 'user_turn_form': 'Override Issued application form',
//'I.d.': 'I.d.',//证件号码
'Id': 'IdNo',
'ID_mumber': 'ID Number ',//身份证
'currcertificationency': 'Not Activation, now go to ',//未认证，现在去认证
'Notcertifiednowgo': 'Not Activation, now go to ',//未认证,现在去
'Authentication':'Activate',//认证
    'Authenticationsuccess': 'Activation success',//认证成功
    'Authenticationfailednowgo': 'Activation is failed, now go to ',//认证失败,现在去
'UserInfoedit': 'Edit',//修改
'Administration':'Administration',//管理
     
//实名认证.
'Vusername_cn': '<span style="color: #dc143c;font-size:18px">*</span> Chinese Name',//认证页面必填项 中文名
'Vusername': '<span style="color: #dc143c;font-size:18px">*</span> English Name',//认证页面必填项 英文名
    'LookInfo': '<span style=\'color:red\'>(Infomation)</span>',//'(查看资料)',
'VIDcard': '<span style="color: #dc143c;font-size:18px">*</span> ID Number',//认证页面必填项 身份证号
'VBirthday': '<span style="color: #dc143c;font-size:18px">*</span> Birthday',//认证页面必填项 出生日期
'id_photo': 'front photo of id card',//身份证正面照片
'id_photo2': 'opposite photo of id card',//身份证反面照片
'positive': 'Click on the upload the front of id card',//点击上传身份证正面
'opposite': 'Click on the upload the opposite id card',//点击上传身份证反面
'card_photo': 'the front of bank card',//银行卡正面
'up_cardphoto': ' upload the front of bank card',//点击上传银行卡正面
'up_cardphoto1': 'upload the Behind of bank card',// '点击上传银行卡反面',
'address_info': 'The address information',//地址信息
'proof_addr': 'Proof of address',//地址证明
'up_addr': 'Click on the upload address document',//点击上传地址文件证明
'verify_result': 'Authentication results: ',//认证结果
'notconfirm_name': '<i style="margin-left:10px;color:#f67467;">X</i>  The name does not match',//姓名不符
'notconfirm_idno': ' <i style="margin-left:10px;color:#f67467;">X</i>  The ID number does not match ',//身份证号不符
'notconfirm_cardtype': '<i style="margin-left:10px;color:#f67467;">X</i>  The type of bank card does not match',//银行卡类型不符
'notconfirm_banktype': '<i style="margin-left:10px;color:#f67467;">X</i>  Bank name does not match ',//开户行名称不符
'notconfirm_cardno': '<i style="margin-left:10px;color:#f67467;">X</i>  Bank card number does not match',//银行卡号不符
'notclear_bankcard': ' <i style="margin-left:10px;color:#f67467;">X</i>  Bank card photo is not clear',//银行卡照片不清晰
'notclear_id': '<i style="margin-left:10px;color:#f67467;">X</i>  ID photo is not clear',//身份证照片不清晰
'notconfirm_bankaddress': '<i style="margin-left:10px;color:#f67467;">X</i>  Bank address does not match',//开户行地址不符
'notconfirm_addressinfo': '<i style="margin-left:10px;color:#f67467;">X</i>  Address information does not match',//地址信息不符
'notclear_addr': '<i style="margin-left:10px;color:#f67467;">X</i>  Authentication failed, address photo is not clear',//认证失败，地址照片不清晰
    'not_8': '<i style="margin-left:10px;color:#f67467;">X</i> Address information not match',
    'not_9': '<i style="margin-left:10px;color:#f67467;">X</i> 	Bank card photos not uploaded',
    'not_10': '<i style="margin-left:10px;color:#f67467;">X</i> ID photos not uploaded',
    'not_11': '<i style="margin-left:10px;color:#f67467;">X</i> ID photo not match',
    'not_12': '<i style="margin-left:10px;color:#f67467;">X</i> Bank card photo not match',
    'not_13': '<i style="margin-left:10px;color:#f67467;">X</i> Information filling error',
    'not_14': '<i style="margin-left:10px;color:#f67467;">X</i> Certificate invalid',
'submit': 'Submit the certification',//提交认证
'identify_test': '<span style="color: #dc143c">In the activation test ...</span> ',//身份激活中......
'certification': 'You have been certified, no longer to re certified!',//您已认证通过 无需再认证!
'authenticationfailed': 'Authentication failed, to certification again',//认证失败，去认证
'example': 'example',//示例
//入金1
'golden_options': 'Golden options',//入金选项
'bank': 'Your money can be transferred directly from your bank account to your account through this way. Bank wire transfer allows you to deposit your local currency.',//这种方式可以从您的银行账户中直接汇款至您在Westfield账户当中。银行电汇允许您存入您的本地货币。然后由收款银行转换为您存款选定接受的货币。
'online': 'You can get fast access service in China by using online payment. The exchange rate is converted based on the same day of Bank of China buying / selling onshore RMB spot exchange rate. ',//使用在线支付的方式，可以让您在中国享受快捷的存取款服务。汇率是以当日中国银行在岸人民币现汇买入/卖出汇率折算。
'online1': 'Your bank card is deducted from the RMB, the currency in the transaction account is your selected currency (usually US dollars).',//您的银行卡扣除的是人民币，交易账户中到账的货币为您选定的货币（一般为美金）。
'online2': 'Based on the anti money laundering regulations, customers who deposit online through RMB that withdrawal also will be in RMB payment way to   account.',//基于反洗钱的条规，通过人民币在线入金的客户，出金时也会以人民币方式出金到您的个人账户。
'visa': 'Payment by credit card / debit card is a simple and safe way to deposit funds into your trading account.',//使用信用卡/借记卡付款是将资金存入您交易账户简单且安全的方式。
'master_card': 'Payment by credit card / debit card is a simple and safe way to deposit funds into your trading account.',//使用信用卡/借记卡付款是将资金存入您交易账户简单且安全的方式。
'paypal': 'Inflation is credited to your account within an hour. Make sure that your Paypal account is registered with the real name and your Paypal email address has been added to your trading account.',//通货膨胀在一个小时内计入您的账户。请确定您使用的Paypal账户是您用实名注册且您的Paypal邮件地址已经加入到您的交易账户记录。
    'Webmoney': 'Webmoney is a worldwide electronic Vault that provides a quick and easy way for you to deposit money into a Fxpro account.',//Webmoney是一种世界范围的电子钱包，提供了快速而简单的方式让您可以将资金存入Fxpro账户。
    'golden_bank_transfer': 'golden',
'golden_bank_online': 'online payment',//在线支付 人民币
'golden_bank_card': 'golden credit card /debit card',
'golden_status': 'golden fail',
'paytypecannot': 'This payment way has not yet opened',

    'paytypecannotinto': '<div style=\'font-size:20px \'>Bank  Infomation:</div><div style=\'text-align:center\'><br/>FINANCIAL  SOLUTIONS  LIMITED<br/>ASB Bank New Zealand<br/>12-3232 - 0293459-00<br/>ASBBNZ2A<br/>ASB North Wharf, 12 Jellicoe Street, Auckland Central, Auckland 1010.<br/><br/><br/>* The UK pubilc accounts only for institutional clients</div>',// '* 英国对公账户只针对机构客户提供',
    'Telegraphictransfer': 'Bank transfer',

    'banking_details': 'wire transfer bank information:',//Westfield 电汇银行信息详情
    'banking_details1': 'BENEFICIARY BANK NAME :',
    'banking_details11': '&nbsp;',

    'banking_details2': 'BANK ADDRESS :',
    'banking_details21': '&nbsp;',

    'banking_details3': 'BENEFICIARY ACCOUNT NAME :',
    'banking_details31': '&nbsp;',

    'banking_details4': 'SWIFT/BIC :',
    'banking_details41': '&nbsp;',

    'banking_details5': 'ACCOUNT NUMBER :',
    'banking_details51': '&nbsp;',


    'important_itemsb1': '',//英国对公账户只针对机构客户提供
    'important_itemsb2': '',//如您有需求请发送邮件至ib@westffs.com询问详情。

    'important_itemsa': 'Important Items:',//重要事项:
    'important_itemsa1': 'we will inject the net value of your online deposit into your wallet. Net value is the initial amount you transfer, minus the inter-bank charge.',//Westfield 会把您转账的净额数值注入到您的钱包。净额数值是您转账最初金额减去银行间的手续费。
    'important_itemsa2': 'we does not charge any wire transfer fees. The minimum amount is $100 or the equivalent of other currencies. ',//Westfield不收取任何电汇手续费。单笔最低数额是100美元或其他货币等值金额。
    'important_itemsa3': 'we does not accept the transfer way of cash to bank, please use your bank account for deposit, because we do not accept the third party deposit.',//Westfield 不接受现金至银行汇款方式，请您使用您的银行账户进行入金操作，我们不接收第三方入金。
    'important_itemsa4': 'Please keep your remittance form after the wire transfer has been completed, and scanning it and send it to xxx@163.com in time.',//电汇完成后请您保留好您的汇款单并扫描发送至 support@westffs.com 的方式及时告知我们。
    'important_itemsa5': 'This will shorten your wire transfer processing time and will be credited to your account in the most accurate and fast way.',//这会缩短您的电汇入金处理时间，并以最准确快速的方式入账到您在Westfield的账户中。
    'important_itemsa6': 'Usually wire transfer will take 3-7 working days, please be patient. ',//通常电汇入金需要3-7个工作日，请您耐心等待。



//网银入金2
'bank_transfer': 'Online banking transfer',//网银转账
'westfield_bank': 'bank',//Westfield 银行
'amount_gold': 'The amount of gold',//入金金额
'amount_gold1': 'The amount of gold($)',//入金金额
    'wallet_bag': 'Vault',
'chouse_bank': 'chose bank',
'btn_4':'the currency exchange rate',
'btn_1': 'Enter the amount does not meet the specification',
'btn_2': 'Data access error',
'btn_3':'This type of currency is not supported',
   
   
'Confirm_request': 'Confirm the request',//确认发送请求
   
'important_items1': 'we will inject the net value of your online deposit into your wallet. Net value is the initial amount of your transfer.',//Westfield会把您转账的净额数值注入到您的钱包。净额数值是您转账最初金额减去银行间的手续费。Westfield不收取任何手续费。
'important_items2': 'we does not charge any deposit fees. The minimum amount is $100, and the maximum amount is $7000 for single deposit.  ',//Westfield不收取任何入金手续费。单笔最低数额是100美元,最高数额是7000美元。
'important_items3': 'we does not accept cash to bank transfer, please use your bank account into the gold operation',//Westfield不接受现金至银行汇款方式，请您使用您的银行账户进行入金操作
//网银入金3
'bank_limit': 'Bank limit',//银行限额
'this_page': 'If the gold is the RMB,this page will appear.',//如果入金是人民币 才出现这个页面
'cc_limit': 'China Construction Bank payment limit',//中国建设银行支付限额
'credit': 'Credit card',//信用卡
'quasi': 'Quasi credit cards and debit cards',//准贷记卡和借记卡
'dynamic_password': 'Dynamic password users and U shield users (contract customers)',//动态口令用户和和U盾用户（签约客户）
'message_password': 'Dynamic password user and short message password card',//动态口令用户和短信口令卡
'single_limit': 'Single limit',//单笔限额
'daily_limit': 'Daily limit',//每日限额
'USBkey': 'There is a convenient payment way: login to the Construction Bank website, and then counter outlets account reserved for opening the self-service mobile phone number, through the online banking customer payment with mobile phone received dynamic verification for online payment. Debit card senior customer application USBkey',//便捷支付：登录建设银行网站，到网点柜面开户时预留手机号码自助申请开通，通过“网银客户支付”凭借收到的手机动态验证进行网上支付。借记卡高级客户需申请USBkey
'deposit_amount': 'Deposit amount:',//存款金额
'amount_payable': 'payable amount:',//应付金额
'confirm_payment': 'Confirm the payment',//确认付款


//入金完毕跳转到-管理资金页面
'withdraw_money': 'Withdraw money',//取款
    'FxPro_Vauit ': 'FxPro Vauit electric Vault',//FxPro Vauit电子钱包
'accepte': 'Already accepted',//已接受
    'westfield_walletusd': 'Vault USD, the page before online banking gold',//Westfield 钱包 USD
//网银出金前页面
    'amount_money': 'Amount Of Money',//出金金额
    'amount_money1': 'Amount Of Money($)',
'fill_amount': 'Fill amount',//填写金额
'note': 'Please note: the name of your bank account must be your name',//请注意：您出金的银行账户名称必须是您本人。
'note1': 'The maximum amount of gold in one day is 1 million yuan, which the amount exceeding this limit will be processed on the next working day',//单日最高出金额度为100万人民币，超过此限制的金额将在下一个工作日进行处理
'note2': 'If you need to change your bank account information, please before bind the bank card in a personal information in the first operation, and then out of gold',//如需要更改您的银行账户信息，请先在个人信息绑定银行卡一项里先操作，之后再出金
'payee_name': 'Payee Name',//收款人姓名
'bank_name': 'Bank Name',//收款银行名称
'bank_address': 'Bank Address',//收款银行名称
'bank_branch': 'Bank Branch',//开户行支行
'payee_ID': 'Payee ID number',//收款人身份证号
're_phone': 'Payee phone number',//收款人电话号码
'auto_display': 'auto display',//自动显示
'request': 'Confirm send request',//确认发送请求
'ch_record': 'Check out the gold record',//查看出金记录
'taketype': 'Withdraw Method',
//出金记录
'gold_record': 'The gold record',//出金记录
'application_time': 'Application time',//申请时间
'cash_withdrawal': 'Cash withdrawal amount',//提现金额
'curr_withdrawal': 'Withdrawal of currency',//提现币种
'collection_information': 'Collection information',//收款信息
'pending_treatment': 'Pending treatment',//待处理
'al_played': 'Have already played',//已打款
'fail': 'Failed: card error',//失败：卡号错误
'alreadyprocessed': 'Already Processed',
'processingfailure': 'Processing Failure',
//代理专区
'agentarea':'Agent Zone',
'link': 'Agent Link',//我的代理链接
'rep_link': 'Copy Agent Link',//复制代理链接
'two-dimensional': 'Generate QR Code',//生成二维码
    'offline_account': 'Subordinate Account',//下线账户
'commission_transfer': 'Commission Clearing',//佣金转钱包
'URL_automatic': 'URL Automatic Generation',//网址自动获取生成
'account_number': 'Account Number',//账号
'transaction_account': 'Transaction Account',//交易账号
'account_properties': 'Account Type',//账号性质
'transaction_number': 'Transaction Number',//交易笔数
'settle_time': 'Settle Time',
    'timesSelect':'Trading volume query',// '交易量查询',
    'allTradeTimes':'Total trading volume:' ,//'总交易量:',
    'allBonus': 'Total commission:',//'总佣金:',  
    'balance': 'Balance',//余额
    'accountInfo':'Account Detail',// '账户详情',
'professional_account': 'Professional account',//专业账户
'copy': 'Copyed',
'confirm_settle': 'Confirm settlement？',
'nobonus': 'You can not settle the commission',
'belong_user': 'belong to the user',
'sure_settle': '<div style=\'text-align:center\'>Commission data synchronizating!<br/>If you need settlement Commission urgently, than please contact us!</div>',
'proxy_user': 'Proxy User',
'personal_user': 'Personal User',
'hands': 'Hand(s)',
'times': 'Time(s)',
'checktradetime': 'Check Transactions',
  'checkcommission': 'Not Settled Commssion Check',
//佣金转钱包
'outstanding_Commission': 'Outstanding Commission',//未结算佣金
'settlement_Commission': 'Settlement Commission',//结算佣金
'order': 'Order',//订单
    
'subordinate_account': 'Subordinate account',//所属账户
'transaction_type': 'Transaction type',//交易类型
    
'time': 'Time',//时间
'return_amount': 'Return amount',//返佣金额

//代理专区
' mt4_Account':'MT4 Account',// 'MT4交易账户',
'pro_money':'Position Profit/Loss',// '盈亏',
    'trade_record': 'Trading Record',//'交易记录',

    'hands_account':'Lots', //'手数',
    'trade_kinds': 'Transaction Variety',//'交易品种',

    
//银行账户页面
'bank_info': 'The bank information',//银行资料
'card_type': '<span style="color: #dc143c;font-size:18px">*</span> The type of bank card',//银行卡类型
'bank_type': '<span style="color: #dc143c;font-size:18px">*</span> Bank Name of deposit',//开户银行
'bank_branc': '<span style="color: #dc143c;font-size:18px">*</span> Bank Branch',//开户行支行
'card_no': '<span style="color: #dc143c;font-size:18px">*</span> Card Number',//银行卡号
'bank_address': 'Bank Address',//银行地址
'card_type1': ' The type of bank card',//银行卡类型
'bank_type1': ' Bank Name of deposit',//开户银行
'bank_branc1': ' Bank Branch',//开户行支行
'card_no1': ' Card Number',//银行卡号
'bank_address1': 'Bank Address',//银行地址

 //MT4账户提取
'Mt4Tradingaccount': 'The MT4 account number already exists:',
'NewEmailAddress': 'New Email Address',
'MakeSureEmailAddress': 'Confirm Email Address',
'extract': 'extract',
'mt4_extract': 'MT4 Account Extract',

    //老客户无邮箱
'noemail': "The Customer did not submit email",
'Mt4pwd': 'MT4 account trading password:',
    'EmailAddress': ' Email Address',
    'MakeSureEmailAddresss': 'Confirm Email Address',
    'makesure': 'make sure',
    'getemailconfirm': 'Make sure this mailbox is bound？',
    'moneyTakeTitle': 'Withdraw application form'
  
}
