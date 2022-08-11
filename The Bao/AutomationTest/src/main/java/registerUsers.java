import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Arrays;
import java.util.concurrent.TimeUnit;

public class registerUsers {
    WebDriver driver;
    public static final String delimiter = ",";
    @Before
    public void Starting() {

        System.setProperty("webdriver.chrome.driver", "C:\\Users\\ADMIN\\Desktop\\chromedriver.exe");
        driver = new ChromeDriver();


        driver.get("http://localhost/orangehrm-4.5/symfony/web/index.php/auth/login");
        driver.manage().window().maximize();

        //login as Admin
        WebElement usernameTxt = driver.findElement(By.id("txtUsername"));
        usernameTxt.sendKeys("admin");

        WebElement passwordTxt = driver.findElement(By.id("txtPassword"));
        passwordTxt.sendKeys("Hiimteebee123.");


        WebElement reLoginBtn = driver.findElement(By.id("btnLogin"));
        reLoginBtn.click();

        driver.navigate().to("http://localhost/orangehrm-4.5/symfony/web/index.php/pim/addEmployee");


        driver.manage().timeouts().implicitlyWait(5L, TimeUnit.SECONDS);

    }

    @Test
    public void Register(){
        try {
            File file = new File("Data.csv");
            FileReader fr = new FileReader(file);
            BufferedReader br = new BufferedReader(fr);
            String line = " ";
            String[] tempArr;
            br.readLine();
            while ((line = br.readLine()) != null) {
                tempArr = line.split(delimiter);
//                WebElement addBtn = driver.findElement(By.id("btnAdd"));
//                addBtn.click();
                WebElement checkBtn = driver.findElement(By.id("chkLogin"));
                checkBtn.click();
                WebElement usernameTxt = driver.findElement(By.id("user_name"));
                usernameTxt.sendKeys(tempArr[0]);
                WebElement passwordTxt = driver.findElement(By.id("user_password"));
                passwordTxt.sendKeys(tempArr[1]);
                WebElement rePasswordTxt = driver.findElement(By.id("re_password"));
                rePasswordTxt.sendKeys(tempArr[2]);
                WebElement firstNameTxt = driver.findElement(By.id("firstName"));
                firstNameTxt.sendKeys(tempArr[3]);
                WebElement lastNameTxt = driver.findElement(By.id("lastName"));
                lastNameTxt.sendKeys(tempArr[4]);
                WebElement saveBtn = driver.findElement(By.id("btnSave"));
                saveBtn.click();
                driver.navigate().refresh();
                driver.navigate().to("http://localhost/orangehrm-4.5/symfony/web/index.php/pim/addEmployee");
//                WebElement reAddBtn = driver.findElement(By.xpath("//*[@id=\"menu_pim_addEmployee\"]"));
//                reAddBtn.click();
            }
            br.close();
        } catch (IOException ioe) {
            ioe.printStackTrace();
        }

    }



    @After
    public void Finish(){

    }
}
