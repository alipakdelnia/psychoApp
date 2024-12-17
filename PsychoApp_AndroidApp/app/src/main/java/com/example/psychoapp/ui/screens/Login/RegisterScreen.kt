package com.example.psychoapp.ui.screens.Login

import android.widget.Toast
import androidx.compose.foundation.layout.*
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.hilt.navigation.compose.hiltViewModel
import androidx.navigation.NavHostController
import com.example.psychoapp.model.data.login.User

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun RegisterScreen(navController: NavHostController, viewModel: RegisterViewModel = hiltViewModel()) {
    var firstName by remember { mutableStateOf("") }
    var lastName by remember { mutableStateOf("") }
    var username by remember { mutableStateOf("") }
    var email by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }
    var confirmPassword by remember { mutableStateOf("") }

    val context = LocalContext.current

    // Observe response from ViewModel
    val response by viewModel.response.observeAsState()

    Scaffold(
        topBar = {
            TopAppBar(
                title = { Text("ثبت نام") }
            )
        },
        content = { padding ->
            Column(
                modifier = Modifier
                    .fillMaxSize()
                    .padding(padding)
                    .padding(16.dp),
                horizontalAlignment = Alignment.CenterHorizontally,
                verticalArrangement = Arrangement.Center
            ) {
                // Fields for user input
                TextField(
                    value = firstName,
                    onValueChange = { firstName = it },
                    label = { Text("نام") },
                    modifier = Modifier.fillMaxWidth()
                )
                Spacer(modifier = Modifier.height(8.dp))
                TextField(
                    value = lastName,
                    onValueChange = { lastName = it },
                    label = { Text("نام خانوادگی") },
                    modifier = Modifier.fillMaxWidth()
                )
                Spacer(modifier = Modifier.height(8.dp))
                TextField(
                    value = username,
                    onValueChange = { username = it },
                    label = { Text("نام کاربری") },
                    modifier = Modifier.fillMaxWidth()
                )
                Spacer(modifier = Modifier.height(8.dp))
                TextField(
                    value = email,
                    onValueChange = { email = it },
                    label = { Text("ایمیل") },
                    modifier = Modifier.fillMaxWidth()
                )
                Spacer(modifier = Modifier.height(8.dp))
                TextField(
                    value = password,
                    onValueChange = { password = it },
                    label = { Text("پسورد") },
                    visualTransformation = PasswordVisualTransformation(),
                    modifier = Modifier.fillMaxWidth()
                )
                Spacer(modifier = Modifier.height(8.dp))
                TextField(
                    value = confirmPassword,
                    onValueChange = { confirmPassword = it },
                    label = { Text("تکرار پسورد") },
                    visualTransformation = PasswordVisualTransformation(),
                    modifier = Modifier.fillMaxWidth()
                )
                Spacer(modifier = Modifier.height(16.dp))

                // SignUp Button
                Button(
                    onClick = {
                        // Trigger ViewModel to call API
                        val user = User(firstName, lastName, username, email, password, "234","234")
                        viewModel.registerUser(user)
                    },
                    modifier = Modifier.fillMaxWidth()
                ) {
                    Text("ثبت نام")
                }

                Spacer(modifier = Modifier.height(16.dp))

                // Navigate to login page if already registered
                TextButton(onClick = { navController.navigate("login") }) {
                    Text("اگر قبلاً ثبت نام کرده‌اید، از اینجا وارد شوید", color = Color.Blue)
                }

                // Show Toast if response is received
                LaunchedEffect(response) {

                        Toast.makeText(context, response?.message.toString(), Toast.LENGTH_SHORT).show()

                }
            }
        }
    )
}


