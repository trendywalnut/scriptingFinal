using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class YarnCommands : MonoBehaviour
{
    static YarnCommands instance;

    public AnimationCurve ease_in_out;

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        DialogueRunner.DoAddCommandHandler("set_fog_density", set_fog_density);
    }

    private void Update()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
    }

    [YarnCommand("DebugLog")]
    public void DebugLog(string debug_msg)
    {
        Debug.Log(debug_msg);
    }

    [YarnCommand("quit")]
    public void quit()
    {
        Application.Quit();
    }

    [YarnCommand("camera_warp_target")]
    public void camera_move(string gameobject_name)
    {
        GameObject target = GameObject.Find(gameobject_name);
        if(target == null)
        {
            Debug.LogError("Yarn command \"camera_move\" did not provide the name of a gameobject.");
            return;
        }

        Camera.main.transform.position = target.transform.position;
        Camera.main.transform.rotation = target.transform.rotation;
    }

    /* One string param expected (name of position target gameobject) */
    [YarnCommand("camera_ease_target")]
    public void camera_ease_target(string gameobject_name)
    {
        float duration_sec = 1.0f;
        GameObject target = GameObject.Find(gameobject_name);

        if(target == null)
        {
            Debug.LogError("Yarn Command camera_ease_target was provided a target gameobject name of [" + gameobject_name + "] but no gameobject with this name exists at the root of the scene hierarchy.");
            return;
        }

        //foreach (string parameter in parameters)
        //    Debug.Log("[ PARAMETER" + parameter + "]");

        StartCoroutine(_ChangePositionOverTime(Camera.main.transform, target.transform, duration_sec, ease_in_out, null));
    }

    [YarnCommand("camera_warp_position")]
    public void camera_warp(string x_str, string y_str, string z_str, string xr_str, string yr_str, string zr_str)
    {
        float x = Camera.main.transform.position.x;
        float y = Camera.main.transform.position.y;
        float z = Camera.main.transform.position.z;

        float xr = Camera.main.transform.rotation.eulerAngles.x;
        float yr= Camera.main.transform.rotation.eulerAngles.y;
        float zr = Camera.main.transform.rotation.eulerAngles.z;

        float.TryParse(x_str, out x);
        float.TryParse(y_str, out y);
        float.TryParse(z_str, out z);

        float.TryParse(xr_str, out x);
        float.TryParse(yr_str, out y);
        float.TryParse(zr_str, out z);

        Camera.main.transform.position = new Vector3(x, y, z);
        Quaternion q = new Quaternion();
        q.eulerAngles = new Vector3(xr, yr, zr);
        Camera.main.transform.rotation = q;
    }

    [YarnCommand("restart_current_scene")]
    public void restart_current_scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [YarnCommand("load_scene")]
    public void load_scene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    [YarnCommand("play_audio_clip")]
    public void play_audio_clip(string audio_clip_path)
    {
        AudioClip clip = Resources.Load<AudioClip>(audio_clip_path);
        if(clip == null)
        {
            Debug.LogError("Yarn command \"play_audio_clip\" could not find audio clip in a resources folder with path [" + audio_clip_path + "]");
            return;
        }

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    /* One string param expected, representing desired density */
    [YarnCommand("set_fog_density")]
    public void set_fog_density(string[] parameters, System.Action onComplete)
    {
        if(parameters.Length <= 1 || parameters[1] == null || parameters[1].Trim() == "")
        {
            Debug.LogError("Yarn Command set_fog_density was not provided with a density parameter.");
            onComplete();
            return;
        }

        //foreach (string parameter in parameters)
        //    Debug.Log("[ PARAMETER" + parameter + "]");

        StartCoroutine(_ChangeFogDensityOverTime(float.Parse(parameters[1]), onComplete));
    }

    IEnumerator _ChangeFogDensityOverTime(float desired_fog_density, System.Action finished_callback)
    {
        float duration_sec = 1.0f;
        float initial_time = Time.time;
        float progress = (Time.time - initial_time) / duration_sec;
        float initial_fog_density = RenderSettings.fogDensity;

        while(progress < 1.0f)
        {
            progress = (Time.time - initial_time) / duration_sec;
            RenderSettings.fogDensity = Mathf.Lerp(initial_fog_density, desired_fog_density, progress);
            yield return null;
        }

        RenderSettings.fogDensity = desired_fog_density;
        finished_callback();
    }

    IEnumerator _ChangePositionOverTime(Transform target_obj, Transform dest_obj, float duration_sec, AnimationCurve ease, System.Action finished_callback)
    {
        float initial_time = Time.time;
        float progress = Time.time - initial_time / duration_sec;
        Vector3 initial_position = target_obj.position;
        Quaternion initial_rotation = target_obj.rotation;

        while(progress < 1.0f)
        {
            progress = Time.time - initial_time / duration_sec;

            float effective_progress = progress;
            if (ease != null)
                effective_progress = ease.Evaluate(effective_progress);

            target_obj.position = Vector3.LerpUnclamped(initial_position, dest_obj.position, effective_progress);
            target_obj.rotation = Quaternion.SlerpUnclamped(initial_rotation, dest_obj.rotation, effective_progress);
            yield return null;
        }

        target_obj.position = Vector3.LerpUnclamped(initial_position, dest_obj.position, 1.0f);
        target_obj.rotation = Quaternion.SlerpUnclamped(initial_rotation, dest_obj.rotation, 1.0f);

        if(finished_callback != null)
            finished_callback();
    }
}
