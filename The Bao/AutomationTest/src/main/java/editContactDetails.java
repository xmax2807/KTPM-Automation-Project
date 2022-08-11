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
import java.util.concurrent.TimeUnit;

public class editContactDetails {
    WebDriver driver;
    public static final String delimiter = ",";
    @Before
    public void Starting() {

        System.setProperty("webdriver.chrome.driver", "C:\\Users\\ADMIN\\Desktop\\chromedriver.exe");
        driver = new ChromeDriver();


        driver.get("http://localhost/orangehrm-4.5/symfony/web/index.php/auth/login");
        driver.manage().window().maximize();


        driver.manage().timeouts().implicitlyWait(5L, TimeUnit.SECONDS);

    }

    @Test
    public void EditContactDetails(){
        try {
            File file = new File("Data.csv");
            FileReader fr = new FileReader(file);
            BufferedReader br = new BufferedReader(fr);
            String line = " ";
            String[] tempArr;
            br.readLine();
            while ((line = br.readLine()) != null) {
                tempArr = line.split(delimiter);

                //login as user
                WebElement usernameTxt = driver.findElement(By.id("txtUsername"));
                usernameTxt.sendKeys(tempArr[0]);

                WebElement passwordTxt = driver.findElement(By.id("txtPassword"));
                passwordTxt.sendKeys(tempArr[1]);


                WebElement reLoginBtn = driver.findElement(By.id("btnLogin"));
                reLoginBtn.click();

                WebElement myInfoBtn = driver.findElement(By.id("menu_pim_viewMyDetails"));
                myInfoBtn.click();

                WebElement contactDetailsBtn = driver.findElement(By.xpath("//*[@id=\"sidenav\"]/li[2]/a"));
                contactDetailsBtn.click();

                WebElement editBtn = driver.findElement(By.id("btnSave"));
                editBtn.click();

                WebElement mobileTxt = driver.findElement(By.id("contact_emp_mobile"));
                mobileTxt.sendKeys(tempArr[5]);
                editBtn.click();

                driver.navigate().to("http://localhost/orangehrm-4.5/symfony/web/index.php/auth/login");

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
